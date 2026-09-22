using HomeHero_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Hero
{
    public enum RequestStatus { Requested, Approved, ProviderAssigned, Scheduled, InProgress, Completed, Cancelled }

    public class MaintenanceRequest
    {
        private Customer customer;
        private Service service;
        private string requestDescription;

        public string RequestNumber { get; set; }
        public string CustomerId { get; set; }
        public string ServiceCategory { get; set; }
        public string ProblemDescription { get; set; }
        public string PropertyAddress { get; set; }
        public DateTime PreferredDate { get; set; }
        public string PreferredTime { get; set; }
        public RequestStatus Status { get; set; }
        public string AssignedProviderId { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal FinalCost { get; set; }
        public object ServiceRequest { get; internal set; }

        public MaintenanceRequest() { }
        public MaintenanceRequest(string customerId, string category, string description, string address, DateTime preferredDate, string preferredTime)
        {
            RequestNumber = "REQ-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            CustomerId = customerId;
            ServiceCategory = category;
            ProblemDescription = description;
            PropertyAddress = address;
            PreferredDate = preferredDate;
            PreferredTime = preferredTime;
            Status = RequestStatus.Requested;
            AssignedProviderId = "Unassigned";
            EstimatedCost = CalculateEstimatedCost(category);
            FinalCost = 0.00m;
        }

        public MaintenanceRequest(Customer customer, Service service, string requestDescription)
        {
            this.customer = customer;
            this.service = service;
            this.requestDescription = requestDescription;
        }

        public static decimal CalculateEstimatedCost(string category)
        {
            decimal callOutFee = 250.00m;

            decimal baseRate = category switch
            {
                "Electrical" => 500.00m,
                "Plumbing" => 400.00m,
                "Appliance Repair" => 350.00m,
                "Painting" => 200.00m,
                "General Maintenance" => 300.00m,
                _ => 0.00m
            };

            return callOutFee + baseRate;
        }
        public bool TryUpdateStatus(RequestStatus newStatus, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (Status == RequestStatus.Completed)
            {
                errorMessage =
                    "A completed job cannot be modified.";

                return false;
            }

            if (Status == RequestStatus.Cancelled)
            {
                errorMessage =
                    "A cancelled request cannot be modified.";

                return false;
            }

            if (newStatus == RequestStatus.Cancelled)
            {
                Status = RequestStatus.Cancelled;
                return true;
            }

            bool validTransition =
                (Status == RequestStatus.Requested &&
                 newStatus == RequestStatus.Approved)

                ||

                (Status == RequestStatus.Approved &&
                 newStatus == RequestStatus.ProviderAssigned)

                ||

                (Status == RequestStatus.ProviderAssigned &&
                 newStatus == RequestStatus.Scheduled)

                ||

                (Status == RequestStatus.Scheduled &&
                 newStatus == RequestStatus.InProgress)

                ||

                (Status == RequestStatus.InProgress &&
                 newStatus == RequestStatus.Completed);

            if (validTransition)
            {
                Status = newStatus;
                return true;
            }

            errorMessage =
                $"Invalid status transition from {Status} to {newStatus}.";

            return false;
        }
    }
}




