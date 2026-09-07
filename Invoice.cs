using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Invoice
    {
        public Guid InvoiceId { get; private set; }
        public Job Job { get; private set; }
        public decimal CostAmount { get; private set; }
        public string Status { get; private set; }

        private static class PaymentStatuses
        {
            public const string Unpaid = "Unpaid";
            public const string Paid = "Paid";
            public const string Refunded = "Refunded";
        }

        public Invoice(Job job, decimal costAmount)
        {
            InvoiceId = Guid.NewGuid();
            Job = job;
            CostAmount = costAmount;
            Status = PaymentStatuses.Unpaid;

        }
        
        public void Paid()
        {
            Status = PaymentStatuses.Paid;
        }
        
        public void Refund()
        {
            Status = PaymentStatuses.Refunded;
        }







    }
}
