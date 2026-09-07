using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Administrator : User
    {
        public Administrator(string firstName, string lastName, string email, string phoneNumber, string password) : base(firstName, lastName, email, phoneNumber,
            password)
        { }

        public override string UserType()
        {
            return "Adiministrator";
        }

        public void AssignProvider(MaintenanceRequest request,ServiceProvider provider)
        {
          request.AssignProvider(provider);
        }

        public Service AddService(string serviceName, string serviceDescription, string serviceCategory, decimal price)
        {
            Guid serviceId = Guid.NewGuid();
            return new Service(serviceId,serviceName, serviceDescription, price, serviceCategory);

        }
    }
}