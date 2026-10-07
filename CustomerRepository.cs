using System;
using System.Collections.Generic;
using System.Text;

namespace HomeHero_2
{
    public class CustomerRepository
    {
        public static List<Customer> Customers { get; } = new List<Customer>(); // creates one list that will hold our registered customers
    }
}
