using Home_Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void WriteToFile(string Name,string emailAddress,string phoneNumber,string passWord)
        {
            string customersFile = "customers.txt";
            File.AppendAllText(customersFile, $"{Name} | {emailAddress} | {phoneNumber} | {passWord}\n");
        }

        public string ReadFromFile(string emailAddress1,string passWord1)
        {
            string customersFile = "customers.txt";
            if (File.Exists(customersFile))
            {
                string[] fileContent = File.ReadAllLines(customersFile);

                foreach(string data in fileContent)
                {
                    string[] eachPart = data.Split('|');

                    string emailAddress = eachPart[1];
                    string password = eachPart[3];
                    
                    if(emailAddress1.Trim().ToLower() == emailAddress.Trim().ToLower() && passWord1.Trim() == password.Trim())
                    {
                        return "Succesful login";
                    }
                }
                
            }
            else
            {
                MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "Unsuccesful login";
        }
      

    }
}
