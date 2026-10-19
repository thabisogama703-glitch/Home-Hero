using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Home_Hero;

namespace HomeHero_2
{
    public class CustomerRepository
    {
        public static List<Customer> Customers { get; } = new List<Customer>(); // creates one list that will hold our registered customers

        public static bool EmailExists(string email)
        {
            string normalizedEmail = email.Trim();

            if (AppSettings.DefaultAdministrators.Any(
                administrator => string.Equals(
                    administrator.EmailAdress,
                    normalizedEmail,
                    StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            string customerFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.CustomerFileName);
            if (File.Exists(customerFile))
            {
                foreach (string line in File.ReadAllLines(customerFile))
                {
                    string[] fields = line.Split('|');
                    if (fields.Length >= 2 &&
                        string.Equals(fields[1].Trim(), normalizedEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return LoadRegisteredServiceProviders().Any(provider =>
                string.Equals(provider.Email, normalizedEmail, StringComparison.OrdinalIgnoreCase));
        }

        public static ServiceProvider? FindServiceProvider(string email, string password)
        {
            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            if (!File.Exists(serviceProviderFile))
            {
                return null;
            }

            foreach (string line in File.ReadAllLines(serviceProviderFile))
            {
                string[] fields = line.Split('|');
                bool legacyFormat = fields.Length >= 6 && fields[1].Contains('@');
                int emailIndex = legacyFormat ? 1 : 2;
                int passwordIndex = legacyFormat ? 2 : 3;
                string storedPassword = fields.Length > passwordIndex ? fields[passwordIndex] : string.Empty;
                bool passwordMatches = legacyFormat
                    ? string.Equals(storedPassword.Trim(), password.Trim(), StringComparison.Ordinal)
                    : string.Equals(storedPassword, password, StringComparison.Ordinal);
                if (fields.Length < (legacyFormat ? 6 : 7) ||
                    !string.Equals(fields[emailIndex].Trim(), email.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    !passwordMatches)
                {
                    continue;
                }

                int specializationIndex = legacyFormat ? 5 : 6;
                List<string> specialisations = fields[specializationIndex]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(specialisation => !specialisation.StartsWith(
                        "System.Collections.Generic.List",
                        StringComparison.Ordinal))
                    .Select(HomeServiceCatalog.NormalizeCategory)
                    .ToList();

                return new ServiceProvider(
                    fields[0].Trim(),
                    legacyFormat ? "" : fields[1].Trim(),
                    fields[emailIndex].Trim(),
                    fields[passwordIndex],
                    fields[legacyFormat ? 3 : 4].Trim(),
                    fields[legacyFormat ? 4 : 5].Trim(),
                    specialisations);
            }

            return null;
        }

        public static bool SaveServiceProvider(ServiceProvider serviceProvider)
        {
            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            try
            {
                List<string> lines = File.Exists(serviceProviderFile)
                    ? File.ReadAllLines(serviceProviderFile).ToList()
                    : new List<string>();
                string record = string.Join("|", new[]
                {
                    serviceProvider.FirstName,
                    serviceProvider.LastName,
                    serviceProvider.Email,
                    serviceProvider.Password,
                    serviceProvider.PhoneNumber,
                    serviceProvider.Location,
                    string.Join(",", serviceProvider.Specialisation)
                });
                int existingIndex = lines.FindIndex(line =>
                {
                    string[] fields = line.Split('|');
                    int emailIndex = fields.Length >= 7 ? 2 : 1;
                    return fields.Length > emailIndex &&
                           string.Equals(fields[emailIndex].Trim(), serviceProvider.Email, StringComparison.OrdinalIgnoreCase);
                });

                if (existingIndex >= 0)
                {
                    lines[existingIndex] = record;
                }
                else
                {
                    lines.Add(record);
                }

                File.WriteAllLines(serviceProviderFile, lines);
                return true;
            }
            catch (IOException exception)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Provider details could not be saved.\n\n{exception.Message}",
                    "File Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            catch (UnauthorizedAccessException exception)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Provider details could not be saved.\n\n{exception.Message}",
                    "File Access Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteServiceProvider(string email)
        {
            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            if (!File.Exists(serviceProviderFile))
            {
                return false;
            }

            List<string> lines = File.ReadAllLines(serviceProviderFile).ToList();
            int originalCount = lines.Count;
            lines.RemoveAll(line =>
            {
                string[] fields = line.Split('|');
                int emailIndex = fields.Length >= 7 ? 2 : 1;
                return fields.Length > emailIndex &&
                       string.Equals(fields[emailIndex].Trim(), email, StringComparison.OrdinalIgnoreCase);
            });

            if (lines.Count == originalCount)
            {
                return false;
            }

            File.WriteAllLines(serviceProviderFile, lines);
            return true;
        }

        public static List<ServiceProvider> LoadRegisteredServiceProviders()
        {
            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            if (!File.Exists(serviceProviderFile))
            {
                return new List<ServiceProvider>();
            }

            List<ServiceProvider> providers = new List<ServiceProvider>();
            foreach (string line in File.ReadAllLines(serviceProviderFile))
            {
                string[] fields = line.Split('|');
                bool legacyFormat = fields.Length >= 6 && fields[1].Contains('@');
                if (fields.Length < (legacyFormat ? 6 : 7))
                {
                    continue;
                }

                int specializationIndex = legacyFormat ? 5 : 6;
                List<string> specialisations = fields[specializationIndex]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(specialisation => !specialisation.StartsWith(
                        "System.Collections.Generic.List",
                        StringComparison.Ordinal))
                    .Select(HomeServiceCatalog.NormalizeCategory)
                    .ToList();

                providers.Add(new ServiceProvider(
                    fields[0].Trim(),
                    legacyFormat ? "" : fields[1].Trim(),
                    fields[legacyFormat ? 1 : 2].Trim(),
                    fields[legacyFormat ? 2 : 3],
                    fields[legacyFormat ? 3 : 4].Trim(),
                    fields[legacyFormat ? 4 : 5].Trim(),
                    specialisations));
            }

            return providers
                .GroupBy(provider => provider.Email, StringComparer.OrdinalIgnoreCase)
                .Select(group => group.First())
                .ToList();
        }
    }
}
