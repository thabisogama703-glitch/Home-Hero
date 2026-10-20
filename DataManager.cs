using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using HomeHero_2;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Home_Hero
{
    public static class DataManager
    {
        private static readonly string filePath =
            AppPaths.DataFile("maintenance_requests.txt");
        private static readonly Mutex requestsMutex = new Mutex(false, @"Local\HomeHero.MaintenanceRequests");

        private static readonly string providerFile =
            AppPaths.DataFile("providers.json");
        public static List<ServiceProvider> LoadServiceProviders()
        {
            if (!File.Exists(providerFile))
                return new List<ServiceProvider>();

            string json = File.ReadAllText(providerFile);

            if (string.IsNullOrWhiteSpace(json))
                return new List<ServiceProvider>();

            try
            {
                return JsonSerializer.Deserialize<List<ServiceProvider>>(json)
                       ?? new List<ServiceProvider>();
            }
            catch (JsonException ex)
            {
                string backup = providerFile + ".broken-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                try
                {
                    File.Copy(providerFile, backup, true);
                }
                catch (IOException backupError)
                {
                    throw new InvalidDataException(
                        "The provider accounts file is invalid and could not be backed up: " + backupError.Message, ex);
                }
                catch (UnauthorizedAccessException backupError)
                {
                    throw new InvalidDataException(
                        "The provider accounts file is invalid and could not be backed up: " + backupError.Message, ex);
                }

                throw new InvalidDataException(
                    "The provider accounts file is invalid. A copy was saved to " + backup + ".", ex);
            }
        }
        public static bool SaveServiceProviders(
           List<ServiceProvider> providers)
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    providers,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText(providerFile, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Providers could not be saved.\n\n" + ex.Message,"File Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool AddServiceProvider(ServiceProvider provider)
        {
            List<ServiceProvider> providers =LoadServiceProviders();

            providers.Add(provider);

            return SaveServiceProviders(providers);
        }
        public static bool UpdateServiceProvider(
            ServiceProvider updatedProvider)
        {
            List<ServiceProvider> providers =
                LoadServiceProviders();

            int index = providers.FindIndex(
                p => p.UserId == updatedProvider.UserId);

            if (index == -1)
                return false;

            providers[index] = updatedProvider;
            return SaveServiceProviders(providers);
        }
        public static bool DeleteServiceProvider(
           Guid userId)
        {
            List<ServiceProvider> providers =
                LoadServiceProviders();

            ServiceProvider provider =providers.FirstOrDefault(p => p.UserId == userId);

            if (provider == null)
                return false;

            providers.Remove(provider);

            SaveServiceProviders(providers);

            return true;
        }



        public static List<MaintenanceRequest> LoadRequests()
        {
            if (!TryLoadRequests(out List<MaintenanceRequest> requests, out string errorMessage))
            {
                MessageBox.Show(
                    "There was a problem reading the maintenance request file.\r\n\r\n" + errorMessage,
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return requests;
        }

        public static bool TryLoadRequests(out List<MaintenanceRequest> requests, out string errorMessage)
        {
            bool acquired = EnterRequestsMutex();
            try
            {
                requests = LoadRequestsUnlocked();
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                requests = new List<MaintenanceRequest>();
                errorMessage = ex.Message;
                return false;
            }
            finally
            {
                if (acquired) requestsMutex.ReleaseMutex();
            }
        }

        private static List<MaintenanceRequest> LoadRequestsUnlocked()
        {
            List<MaintenanceRequest> requests =
                new List<MaintenanceRequest>();

            if (!File.Exists(filePath))
            {
                return requests;
            }

            string[] fileContent = File.ReadAllLines(filePath);

            foreach (string line in fileContent)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] data = line.Split('|');

                if (data.Length < 11)
                {
                    continue;
                }

                MaintenanceRequest request = new MaintenanceRequest();

                request.SetRequestNumber(data[0]);
                request.CustomerId = data[1];
                request.ServiceCategory = data[2];
                request.ProblemDescription = data[3];
                request.PropertyAddress = data[4];
                request.PreferredDate =
                    DateTime.Parse(data[5]);
                request.PreferredTime = data[6];

                request.Status =
                    (RequestStatus)Enum.Parse(
                        typeof(RequestStatus),
                        data[7]);

                request.AssignedProviderId = data[8];
                request.EstimatedCost =
                    decimal.Parse(data[9]);
                request.FinalCost =
                    decimal.Parse(data[10]);

                requests.Add(request);
            }

            return requests;
        }


        public static bool SaveRequests(List<MaintenanceRequest> requests)
        {
            bool acquired = EnterRequestsMutex();
            try
            {
                return SaveRequestsUnlocked(requests);
            }
            finally
            {
                if (acquired) requestsMutex.ReleaseMutex();
            }
        }

        public static bool TryClaimApprovedRequest(
            string requestNumber,
            string providerId,
            IReadOnlyCollection<string> specialisations,
            out string errorMessage)
        {
            errorMessage = "";
            bool acquired = EnterRequestsMutex();
            try
            {
                List<MaintenanceRequest> requests = LoadRequestsUnlocked();
                MaintenanceRequest? request = requests.FirstOrDefault(r =>
                    string.Equals(r.RequestNumber, requestNumber, StringComparison.OrdinalIgnoreCase));
                if (request == null)
                {
                    errorMessage = "This request could not be found. Refresh the available requests and try again.";
                    return false;
                }
                if (request.Status != RequestStatus.Approved
                    || (!string.IsNullOrWhiteSpace(request.AssignedProviderId)
                        && !string.Equals(request.AssignedProviderId.Trim(), "Unassigned", StringComparison.OrdinalIgnoreCase)))
                {
                    errorMessage = "This request has changed or has already been claimed. Refresh the available requests and try again.";
                    return false;
                }
                if (specialisations.Count > 0 && !specialisations.Any(skill =>
                    string.Equals(skill, request.ServiceCategory, StringComparison.OrdinalIgnoreCase)))
                {
                    errorMessage = "This request does not match your service specialisations.";
                    return false;
                }

                if (!request.TryUpdateStatus(RequestStatus.ProviderAssigned, out errorMessage))
                    return false;

                request.AssignedProviderId = providerId;
                return SaveRequestsUnlocked(requests);
            }
            catch (Exception ex)
            {
                errorMessage = "The request could not be claimed: " + ex.Message;
                return false;
            }
            finally
            {
                if (acquired) requestsMutex.ReleaseMutex();
            }
        }

        private static bool SaveRequestsUnlocked(List<MaintenanceRequest> requests)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (MaintenanceRequest request in requests)
                    {
                        writer.WriteLine(
                            request.RequestNumber + "|" +
                            request.CustomerId + "|" +
                            request.ServiceCategory + "|" +
                            request.ProblemDescription + "|" +
                            request.PropertyAddress + "|" +
                            request.PreferredDate.ToString("yyyy-MM-dd") + "|" +
                            request.PreferredTime + "|" +
                            request.Status + "|" +
                            request.AssignedProviderId + "|" +
                            request.EstimatedCost + "|" +
                            request.FinalCost);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The maintenance requests could not be saved.\r\n\r\n" + ex.Message,
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool EnterRequestsMutex()
        {
            try
            {
                requestsMutex.WaitOne();
                return true;
            }
            catch (AbandonedMutexException)
            {
                return true;
            }
        }

        public static bool AddRequest(MaintenanceRequest request)
        {
            List<MaintenanceRequest> requests = LoadRequests();

            requests.Add(request);

            return SaveRequests(requests);
        }
    }
}
