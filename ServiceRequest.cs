using System;
using System.Collections.Generic;
using System.Text;

namespace HomeHero
{
    public class ServiceRequest
    {
        public Guid RequestId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceCategory { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime PreferredDate { get; set; }
        public string Status { get; set; }
        public string AssignedProvider { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal FinalCost { get; set; }
    }
}
