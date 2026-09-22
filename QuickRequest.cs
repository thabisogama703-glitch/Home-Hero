using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Home_Hero
{
    public class QuickRequest
    {
        public string serviceName { get; set; }

        public bool priorityLevelUrgent { get; set; }
        public string Problemdescription { get; set; }

        public DateTimePicker Date { get; set; }

        public string requestedTime { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }

        public string phoneNumber { get; set; }

        public string address { get; set; }

        public QuickRequest(string serviceName,bool priorityLevelurgent,string problemDEscription,DateTimePicker date,string requestedTime,string firstName,string lastName,string emailAddress,string phoneNumber,string address)
        {
            this.serviceName = serviceName;
            this.priorityLevelUrgent = priorityLevelurgent;
            this.Problemdescription = problemDEscription;
            this.Date = date;
            this.requestedTime = requestedTime;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
            
        }

        public void WriteToFile()
        {
            string filePath = "QuickRequest.txt";
            string priorityLevel = "";

            if (priorityLevelUrgent == true)
            {
                priorityLevel = "Urgent";
            }
            else
            {
                priorityLevel = "Normal";
            }

            File.AppendAllText(filePath, $"{serviceName} | {priorityLevel} | {Problemdescription} | {Date} | {requestedTime} | {firstName} | {lastName} | {emailAddress} | {phoneNumber} | {address} \n");
        }
    }
}
