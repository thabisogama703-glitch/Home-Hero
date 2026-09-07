using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Appointment
    {
        public Guid AppointmentId { get; private set; }
        public MaintenanceRequest Request { get; private set; }
        public ServiceProvider Provider { get; private set; }
         public DateTime DateTime { get; private set; }
        public string Status { get; private set; }

        private static class AppointmentStatuses
        {
            public const string Pending = "Pending";
            public const string StartJob= " Starting the job";
            public const string Completed = "Completed";
            public const string Scheduled = "Scheduled";
            public const string Cancelled = "Cancelled";
            public const string Rescheduled = "Rescheduled";
        }

        public Appointment(MaintenanceRequest request,ServiceProvider provider, DateTime dateTime)
        {
            AppointmentId = Guid.NewGuid();
            Request = request;
            Provider = provider;
            DateTime = dateTime;
            Status = AppointmentStatuses.Scheduled;
        }

        public Job StartJob()
        {
            Status = AppointmentStatuses.StartJob;
            return new Job(this);
        }

        public void CancelJob()
        {
            Status = AppointmentStatuses.Cancelled;
        }
        public void RescheduleJob(DateTime newDateTime)
        {
            Status = AppointmentStatuses.Rescheduled;
            DateTime = newDateTime;
        }

        public void CompletedJob ()
        {
            Status = AppointmentStatuses.Completed;
        }





    }
}
