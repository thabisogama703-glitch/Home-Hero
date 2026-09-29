using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HomeHero_2;

namespace Home_Hero
{
    public static class DataManager
    {
        private static readonly string filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maintenance_requests.txt");

        private static readonly string providerFile =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "providers.json");
        public static List<ServiceProvider> LoadServiceProviders()
        {
            if (!File.Exists(providerFile))
                return new List<ServiceProvider>();

            string json = File.ReadAllText(providerFile);

            if (string.IsNullOrWhiteSpace(json))
                return new List<ServiceProvider>();

            return JsonSerializer.Deserialize<List<ServiceProvider>>(json)
                   ?? new List<ServiceProvider>();
        }


        public static List<MaintenanceRequest> LoadRequests()
        {
            List<MaintenanceRequest> requests =
                new List<MaintenanceRequest>();

            if (!File.Exists(filePath))
            {
                return requests;
            }

            try
            {
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
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "There was a problem reading the maintenance request file.",
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return requests;
        }


        public static void SaveRequests(List<MaintenanceRequest> requests)
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
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "The maintenance requests could not be saved.",
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        public static void AddRequest(MaintenanceRequest request)
        {
            List<MaintenanceRequest> requests = LoadRequests();

            requests.Add(request);

            SaveRequests(requests);
        }
    }
}
