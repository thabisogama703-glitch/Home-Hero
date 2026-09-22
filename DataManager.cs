using HomeHero_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Home_Hero
{
    public static class DataManager
    {
        private static readonly string filePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maintenance_requests.json");
        private static readonly string providerFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "providers.json");

        public static List<ServiceProvider1> LoadServiceProviders()
        {
            if (!File.Exists(providerFile)) return new List<ServiceProvider1>();
            string json = File.ReadAllText(providerFile);
            if (string.IsNullOrWhiteSpace(json)) return new List<ServiceProvider1>();
            return JsonSerializer.Deserialize<List<ServiceProvider1>>(json) ?? new List<ServiceProvider1>();
        }


        public static List<MaintenanceRequest1> LoadRequests()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<MaintenanceRequest1>();
                }

                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<MaintenanceRequest1>();
                }

                return JsonSerializer.Deserialize<List<MaintenanceRequest1>>(json)
                       ?? new List<MaintenanceRequest1>();
            }
            catch
            {
                return new List<MaintenanceRequest1>();
            }
        }

        public static void SaveRequests(List<MaintenanceRequest1> requests)
        {
            string json = JsonSerializer.Serialize(
                requests,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }

        public static void AddRequest(MaintenanceRequest1 request)
        {
            List<MaintenanceRequest1> requests = LoadRequests();

            requests.Add(request);

            SaveRequests(requests);
        }
    }
}
