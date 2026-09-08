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

        public static List<MaintenanceRequest> LoadRequests()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<MaintenanceRequest>();
                }

                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<MaintenanceRequest>();
                }

                return JsonSerializer.Deserialize<List<MaintenanceRequest>>(json)
                       ?? new List<MaintenanceRequest>();
            }
            catch
            {
                return new List<MaintenanceRequest>();
            }
        }

        public static void SaveRequests(List<MaintenanceRequest> requests)
        {
            string json = JsonSerializer.Serialize(
                requests,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(filePath, json);
        }

        public static void AddRequest(MaintenanceRequest request)
        {
            List<MaintenanceRequest> requests = LoadRequests();

            requests.Add(request);

            SaveRequests(requests);
        }
    }
}
