using System;
using System.Collections.Generic;
using System.Text;
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

            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            if (File.Exists(serviceProviderFile))
            {
                foreach (string line in File.ReadAllLines(serviceProviderFile))
                {
                    string[] fields = line.Split('|');
                    if (fields.Length >= 2 &&
                        string.Equals(fields[1].Trim(), normalizedEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
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
                if (fields.Length < 6 ||
                    !string.Equals(fields[1].Trim(), email.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(fields[2].Trim(), password.Trim(), StringComparison.Ordinal))
                {
                    continue;
                }

                List<string> specialisations = fields[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(specialisation => !specialisation.StartsWith(
                        "System.Collections.Generic.List",
                        StringComparison.Ordinal))
                    .ToList();

                return new ServiceProvider(
                    fields[0].Trim(),
                    "",
                    fields[1].Trim(),
                    fields[2].Trim(),
                    fields[3].Trim(),
                    fields[4].Trim(),
                    specialisations);
            }

            return null;
        }

        public static void SaveServiceProvider(ServiceProvider serviceProvider)
        {
            string serviceProviderFile = AppSettings.GetBaseDirectoryFilePath(AppSettings.ServiceProviderFileName);
            string specialisations = string.Join(",", serviceProvider.Specialisation);
            string record = $"{serviceProvider.FirstName}|{serviceProvider.Email}|{serviceProvider.Password}|{serviceProvider.PhoneNumber}|{serviceProvider.Location}|{specialisations}";
            File.AppendAllText(serviceProviderFile, record + Environment.NewLine);
        }
    }
}
