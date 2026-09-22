using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Job1
    {
        public Guid JobId { get; private set; }
        public Appointment1 Appointment { get; private set; }
        public string Status { get; private set; }
        public Invoice1 Invoice { get; private set; }
     

    public Job1(Appointment1 appointment)
        {
            Status = JobStatuses1.NotStarted;
            JobId = Guid.NewGuid();
            Appointment = appointment;
        }

       public void StatusUpdate (string newStaus)
        {
            Status = newStaus;
        }

        //public Invoice CreateInvoice()
        //{
        //    decimal cost = Appointment.Request.ServiceRequest.CalculateCost();
        //    Invoice = new Invoice(this, cost);
        //    return Invoice;
        //}
    }
}