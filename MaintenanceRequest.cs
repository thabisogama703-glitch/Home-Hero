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
        public string RequestNumber { get; private set; }
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

        public MaintenanceRequest() { }
        public MaintenanceRequest(string customerId, string category, string description, string address, DateTime preferredDate, string preferredTime)
        {
            RequestNumber = "REQ-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
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

        public decimal CalculateEstimatedCost(string category)
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
            if (Status == RequestStatus.Completed || Status == RequestStatus.Cancelled)
            {
                errorMessage = "Cannot modify a job that is already completed or cancelled!";
                return false;
            }

            if (newStatus == RequestStatus.Cancelled)
            {
                Status = RequestStatus.Cancelled;
                return true;
            }
            if ((int)newStatus == (int)Status + 1)
            {
                Status = newStatus;
                return true;
            }
            errorMessage = $"Invalid status transition from {Status} to {newStatus}";
            return false;
        }





    }
}


    

