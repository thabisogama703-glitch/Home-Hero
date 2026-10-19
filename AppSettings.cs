using System;
using System.Collections.Generic;
using System.IO;

namespace Home_Hero
{
    public static class AppSettings
    {
        public const string MaintenanceRequestsFileName = "maintenance_requests.txt";
        public const string ProvidersFileName = "providers.json";
        public const string CustomerFileName = "customers.txt";
        public const string ServiceProviderFileName = "Service.txt";
        public const string RememberMeFileName = "Remember.txt";
        public const string QuickRequestFileName = "QuickRequest.txt";
        public const string MessagesFileName = "messages.json";

        public static IReadOnlyList<Administrator> DefaultAdministrators =>
            new[]
            {
                CreateAdministrator("Thabiso", "thabisogama703@gmail.com", "@Thandolwami07"),
                CreateAdministrator("Sibusiso", "shadowsilver308@gmail.com", "@Thandolwami07")
            };

        public static string GetBaseDirectoryFilePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public static Administrator CreateAdministrator(string adminName, string emailAddress, string password)
        {
            return new Administrator
            {
                AdminName = adminName,
                EmailAdress = emailAddress.ToLowerInvariant(),
                Password = password
            };
        }
    }
}
