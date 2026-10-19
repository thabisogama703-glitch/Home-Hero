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

        public static IReadOnlyList<Administrator> DefaultAdministrators =>
            new[]
            {
                CreateAdministrator("Thabiso", "thabisogama703@gmail.com", "@Thandolwami07"),
                CreateAdministrator("Sibusiso", "shadowsilver308@gmail.com", "@Thandolwami07")
            };

        public static IReadOnlyList<object[]> DefaultActiveRequests =>
            new[]
            {
                new object[] { "REQ001", "Plumbing", "Leaking kitchen tap", "22/09/2026", "R450", "In Progress" },
                new object[] { "REQ003", "General Maintanance", "Lawn & tree trimming", "26/09/2026", "R500", "Assigned" },
                new object[] { "REQ023", "Electrical", "Faulty wall socket", "24/10/2026", "R680", "Pending" }
            };

        public static IReadOnlyList<object[]> DefaultServiceHistory =>
            new[]
            {
                new object[] { "REQ101", "Painting", "08/09/2026", "R1500", "Completed" },
                new object[] { "REQ107", "Appliance Repair", "26/08/2026", "R700", "Completed" },
                new object[] { "REQ704", "Plumbing", "18/08/2026", "R450", "Completed" },
                new object[] { "REQ105", "General Maintance", "15/07/2026", "R390", "Completed" },
                new object[] { "REQ112", "Electrical", "07/07/2026", "R400", "Completed" },
                new object[] { "REQ641", "Plumbing", "27/06/2026", "R520", "Completed" }
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
