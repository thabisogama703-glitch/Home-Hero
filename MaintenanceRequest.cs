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
        public object ServiceRequest { get; internal set; }

        public void SetRequestNumber(string requestNumber)
        {
            RequestNumber = requestNumber;
        }
        public void SetStatusFromFile(RequestStatus status)
        {
            Status = status;
        }
        public void SetCostsFromFile(decimal estimatedCost, decimal finalCost)
        {
            EstimatedCost = estimatedCost;
            FinalCost = finalCost;
        }



        public MaintenanceRequest() { }
        public MaintenanceRequest(string customerId, string category, string description, string address, DateTime preferredDate, string preferredTime)
        {
            RequestNumber = "REQ-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff");
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

            RequestNumber = "REQ-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff");
            Status = RequestStatus.Requested;
            AssignedProviderId = "Unassigned";
            EstimatedCost = 0.00m;
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
            errorMessage = "";

            if (Status == RequestStatus.Completed)
            {
                errorMessage = "A completed request cannot be updated.";
                return false;
            }

            if (Status == RequestStatus.Cancelled)
            {
                errorMessage = "A cancelled request cannot be updated.";
                return false;
            }

            if (newStatus == RequestStatus.Cancelled)
            {
                Status = RequestStatus.Cancelled;
                return true;
            }

            bool validTransition = false;

            switch (Status)
            {
                case RequestStatus.Requested:
                    if (newStatus == RequestStatus.Approved)
                    {
                        validTransition = true;
                    }
                    break;

                case RequestStatus.Approved:
                    if (newStatus == RequestStatus.ProviderAssigned)
                    {
                        validTransition = true;
                    }
                    break;

                case RequestStatus.ProviderAssigned:
                    if (newStatus == RequestStatus.Scheduled)
                    {
                        validTransition = true;
                    }
                    break;

                case RequestStatus.Scheduled:
                    if (newStatus == RequestStatus.InProgress)
                    {
                        validTransition = true;
                    }
                    break;

                case RequestStatus.InProgress:
                    if (newStatus == RequestStatus.Completed)
                    {
                        validTransition = true;
                    }
                    break;
            }

            if (validTransition)
            {
                Status = newStatus;
                return true;
            }

            errorMessage =
                $"Invalid status transition from {Status} to {newStatus}.";

            return false;
        }

        public bool ValidateRequest(out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(CustomerId))
            {
                errorMessage = "Customer information is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ServiceCategory))
            {
                errorMessage = "Please select a service category.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ProblemDescription))
            {
                errorMessage = "Please provide a description of the problem.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(PropertyAddress))
            {
                errorMessage = "Please provide the property address.";
                return false;
            }

            if (PreferredDate.Date < DateTime.Today)
            {
                errorMessage = "The preferred appointment date cannot be in the past.";
                return false;
            }

            if (EstimatedCost < 0)
            {
                errorMessage = "Estimated cost cannot be negative.";
                return false;
            }

            if (FinalCost < 0)
            {
                errorMessage = "Final cost cannot be negative.";
                return false;
            }

            return true;
        }


    }
}


    

