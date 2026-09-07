using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Service
    {

        public Guid ServiceId { get; private set; }
        public string ServiceName { get;  set; }
        public string ServiceDescription { get; set; }
        public string ServiceCategory { get; set; }
        public decimal Price { get; set; }

        public Service(Guid serviceId,string serviceName, string serviceDescription, decimal price,string serviceCategory )
        {
            ServiceName = serviceName;
            ServiceId = serviceId;
            ServiceCategory = serviceCategory;
            ServiceDescription = serviceDescription;
            Price = price;
        }

        public decimal CalculateCost()
        {
            return Price;
        }

    }
}
