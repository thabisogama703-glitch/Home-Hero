using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeHero_2
{
    public abstract class User
    {
        public Guid UserId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get;  protected set; }
        public string PhoneNumber { get; protected set; }

        private string _password;

        public User (string firstName , string lastName,string phoneNumber,string email, string password) 
        {
            UserId = Guid.NewGuid();
            FirstName = firstName.Trim().ToUpper();
            LastName = lastName.Trim().ToUpper();
            Email = email;
            PhoneNumber = phoneNumber;
            
            SetPassword(password);
        }  
        
        public void SetPassword(string password) 
        {
             _password = password;

        }
        public bool VerifyPassword (string inputPassword)
        {
            return _password == inputPassword;
        }

        public abstract string UserType();

        public virtual string DisplayUserInformation()
        {
            return ($"User Type: {UserType()} \nFullname: {FirstName} {LastName} \nEmail: {Email} \nPhone Number: {PhoneNumber}");
        }



    }
}
