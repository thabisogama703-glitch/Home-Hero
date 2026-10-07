using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeHero_2
{
    public class Review
    {
        public Guid ReviewId { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime DatePosted { get; private set; }
        public Job Job { get; private set; }
        public Customer Customer { get; private set; }

        public Review(Customer customer,Job job,int rating,string comment)
        {
         
                ReviewId = Guid.NewGuid();
                Customer=customer;
                Job = job;
                Rating = rating;
                Comment = comment;
                DatePosted = DateTime.Now;

            
        }

        public static bool ReviewValidation(Customer  customer,Job job,int rating , string comment,out Review review,out string error)
        {
            if (rating<1 || rating >5)
            {
                review = null;
                error = "Rating must be between 1 and 5";
                return false;
            }
            
            review = new Review(customer,job,rating,comment);
            error = null;
            return true;
         
        }
    }
}
