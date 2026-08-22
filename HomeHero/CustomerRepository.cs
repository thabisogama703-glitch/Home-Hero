using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero
{
    public class CustomerRepository
    {
        public static List<Customer> Customers { get; } = new List<Customer>(); // creates one list that will hold our registered customers
    }
}
