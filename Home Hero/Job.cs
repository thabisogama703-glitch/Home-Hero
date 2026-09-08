using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Job
    {
        public Guid JobId { get; private set; }
        public Appointment Appointment { get; private set; }
        public string Status { get; private set; }
        public Invoice Invoice { get; private set; }
     

    public Job(Appointment appointment)
        {
            Status = JobStatuses.NotStarted;
            JobId = Guid.NewGuid();
            Appointment = appointment;
        }

       public void StatusUpdate (string newStaus)
        {
            Status = newStaus;
        }

        public Invoice CreateInvoice()
        {
            decimal cost = Appointment.Request.ServiceRequest.CalculateCost();
            Invoice = new Invoice(this, cost);
            return Invoice;
        }
    }
}