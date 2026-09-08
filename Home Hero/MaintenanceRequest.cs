<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class MaintenanceRequest
    {
        public Guid RequestId { get; private set; }
        public Customer Customer { get; private set; }
        public Service ServiceRequest { get; private set; }
        public string RequestDescription { get; private set; }
        public string Status { get; private set; }
        public DateTime RequestDate{ get; private set; }
        public ServiceProvider AssignedProvider { get; private set; }
        public Appointment ScheduledAppointmment { get; private set; }

        private static class RequestStatuses
        {
            public const string Pending = "Pending";
            public const string Approved = "Approved";
            public const string Rejected = "Rejected";
            public const string Commpleted = "Completed";
            public const string Cancelled = "Cancelled";
        }

        public MaintenanceRequest(Customer customer,Service service,string description)
        {
            RequestId = Guid.NewGuid();
            Customer = customer;
            ServiceRequest = service;
            Status = RequestStatuses.Pending;
            RequestDate = DateTime.Now;
        }
         public void AssignProvider (ServiceProvider provider)
        {
            AssignedProvider = provider;
            Status = RequestStatuses.Approved;
        }
      
       public bool ScheduledAppointmentValidation(MaintenanceRequest maintenanceRequest,ServiceProvider assignedProvider,DateTime dateTime,out Appointment scheduledAppointment,out string error)
        {
            if (assignedProvider==null)
            {
                scheduledAppointment = null;
                error = "Assign a provider before scheduling an appointment.";
                return  false;
            }

            scheduledAppointment = new Appointment(maintenanceRequest, assignedProvider, dateTime);
            error = null;
            return true;
        }
       
        public void RequestCompleted()
        {
            Status = RequestStatuses.Commpleted;
        }

        public void CancelRequest()
        {
            Status = RequestStatuses.Cancelled;
        }
    }
}
=======
﻿using System;
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


    

>>>>>>> 0a21678 (Fix issues in Home Hero)
