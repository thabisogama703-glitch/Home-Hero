using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class ServiceProvider1 : User1
    {
        public List<string> Specialisation { get; private set; }
        public List<Job1> Assignedjobs { get; private set; }

        public ServiceProvider1(string firstName, string lastName, string email, string password, string phoneNumber, List<string> specialisation = null) : base(firstName, lastName, email, phoneNumber, password)
        {
            Assignedjobs = new List<Job1>();
            Specialisation = new List<string>();
        }

        public override string UserType()
        {
            return "Service Provider";
        }

        public void JobAccepted(Job1 job)
        {
            Assignedjobs.Add(job);
            job.StatusUpdate(JobStatuses1.InProgress);
        }
        public void JobCompleted (Job1 job)
        {
            job.StatusUpdate(JobStatuses1.Completed) ;
        }

    }       




    
}
