using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProviderDashboard

{
    public class Customer : User
    {
        public List<MaintenanceRequests> Requests { get; private set; }
        public List<Review> Reviews { get; protected set; }
        public Customer(string firstName, string lastName,string email,string phoneNumber, string password) : base(firstName,lastName,email,phoneNumber,password)
        {
            Requests = new List<MaintenanceRequests>();
            Reviews = new List<Review>();
        }

        public override string UserType()
        {
            return "Custommer";
        }

        public MaintenanceRequests SubmitRequest (Service service, string requestDescription)
        {
            MaintenanceRequests request = new MaintenanceRequests(this, service, requestDescription);
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
