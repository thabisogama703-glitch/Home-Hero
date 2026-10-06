using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public class ServiceProvider : User
    {
        public List<string> Specialisation { get; private set; }
        public List<Job> Assignedjobs { get; private set; }
        public string Location { get; private set; }


        public ServiceProvider(string firstName, string lastName, string email, string password, string phoneNumber, string location, List<string> specialisation = null) : base(firstName, lastName, phoneNumber,email, password)
        {
            Assignedjobs = new List<Job>();
            Specialisation = specialisation ?? new List<string>();
            Location = location;
        }

        public override string UserType()
        {
            return "Service Provider";
        }

        public void JobAccepted(Job job)
        {
            Assignedjobs.Add(job);
            job.StatusUpdate(JobStatuses.InProgress);
        }
        public void JobCompleted (Job job)
        {
            job.StatusUpdate(JobStatuses.Completed) ;
        }

    }       




    
}
