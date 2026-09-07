using System;
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
