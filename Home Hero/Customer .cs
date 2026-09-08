using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class Customer : User
    {
        public List<MaintenanceRequest> Requests { get; private set; }
        public List<Review> Reviews { get; protected set; }
        public Customer(string firstName, string lastName,string email,string phoneNumber, string password) : base(firstName,lastName,email,phoneNumber,password)
        {
            Requests = new List<MaintenanceRequest>();
            Reviews = new List<Review>();
        }

        public override string UserType()
        {
            return "Custommer";
        }

        public MaintenanceRequest SubmitRequest (Service service, string requestDescription)
        {
            MaintenanceRequest request = new MaintenanceRequest(this, service, requestDescription);
            Requests.Add(request);
            return request;
        }

        public Review LeaveReview(Job job , int rating , string comment)
        {
            Review review = new Review(this, job, rating, comment);
            Reviews.Add(review);
            return review;
        }

        public bool LeaveReviewValidation (Customer customer,Job job,int rating,string comment,out Review review,out string error)
        {
            if (!Review.ReviewValidation(customer, job, rating, comment, out review, out error))
            {
                return false;
            }
            

            Reviews.Add(review);
            return true;
           
        }
      

    }
}
