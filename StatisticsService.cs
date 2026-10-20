using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using HomeHero_2;

namespace Home_Hero
{
    internal sealed class HomePageStatistics
    {
        public int CompletedJobs { get; set; }
        public int VerifiedProviders { get; set; }
        public int ActiveServiceCategories { get; set; }
        public int TotalCustomersServed { get; set; }
    }

    /// <summary>
    /// Reads public-homepage statistics from the application's persisted request
    /// and provider stores. The app currently uses local text/JSON files, not SQL.
    /// </summary>
    internal sealed class StatisticsService
    {
        public HomePageStatistics GetHomePageStatistics()
        {
            List<MaintenanceRequest> requests = LoadRequestsSafely();
            List<ServiceProvider> providers = LoadProvidersSafely();
            List<ServiceProvider> verifiedProviders = providers.Where(p => p.IsVerified).ToList();
            List<MaintenanceRequest> completedRequests = requests
                .Where(r => r.Status == RequestStatus.Completed)
                .ToList();

            return new HomePageStatistics
            {
                CompletedJobs = completedRequests.Count,
                VerifiedProviders = verifiedProviders.Count,
                ActiveServiceCategories = verifiedProviders
                    .Where(p => p.Specialisation != null)
                    .SelectMany(p => p.Specialisation)
                    .Where(category => !string.IsNullOrWhiteSpace(category))
                    .Select(category => category.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Count(),
                TotalCustomersServed = completedRequests
                    .Select(r => r.CustomerId)
                    .Where(customerId => !string.IsNullOrWhiteSpace(customerId))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Count()
            };
        }

        public int GetCompletedJobsCount()
        {
            return LoadRequestsSafely().Count(r => r.Status == RequestStatus.Completed);
        }

        public int GetVerifiedProvidersCount()
        {
            return LoadProvidersSafely().Count(provider => provider.IsVerified);
        }

        public int GetServiceCategoriesCount()
        {
            return LoadProvidersSafely()
                .Where(provider => provider.IsVerified && provider.Specialisation != null)
                .SelectMany(provider => provider.Specialisation)
                .Where(category => !string.IsNullOrWhiteSpace(category))
                .Select(category => category.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();
        }

        public int GetTotalCustomersServed()
        {
            return LoadRequestsSafely()
                .Where(request => request.Status == RequestStatus.Completed)
                .Select(request => request.CustomerId)
                .Where(customerId => !string.IsNullOrWhiteSpace(customerId))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();
        }

        private static List<MaintenanceRequest> LoadRequestsSafely()
        {
            if (DataManager.TryLoadRequests(out List<MaintenanceRequest> requests, out string error))
            {
                return requests;
            }

            Trace.TraceError("Unable to load homepage request statistics: {0}", error);
            return new List<MaintenanceRequest>();
        }

        private static List<ServiceProvider> LoadProvidersSafely()
        {
            try
            {
                return DataManager.LoadServiceProviders();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is InvalidDataException)
            {
                Trace.TraceError("Unable to load homepage provider statistics: {0}", ex);
                return new List<ServiceProvider>();
            }
        }
    }
}
