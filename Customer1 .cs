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
    public class Customer : User1
    {
        public List<MaintenanceRequest1> Requests { get; private set; }
        public List<Review1> Reviews { get; protected set; }
        public Customer(string firstName, string lastName,string email,string phoneNumber, string password) : base(firstName,lastName,email,phoneNumber,password)
        {
            Requests = new List<MaintenanceRequest1>();
            Reviews = new List<Review1>();
        }

        public override string UserType()
        {
            return "Custommer";
        }

        public MaintenanceRequest1 SubmitRequest (Service1 service, string requestDescription)
        {
            MaintenanceRequest1 request = new MaintenanceRequest1(this, service, requestDescription);
            Requests.Add(request);
            return request;
        }

        public Review1 LeaveReview(Job1 job , int rating , string comment)
        {
            Review1 review = new Review1(this, job, rating, comment);
            Reviews.Add(review);
            return review;
        }

        public bool LeaveReviewValidation (Customer customer,Job1 job,int rating,string comment,out Review1 review,out string error)
        {
            if (!Review1.ReviewValidation(customer, job, rating, comment, out review, out error))
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
