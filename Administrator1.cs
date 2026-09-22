using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Hero
{
    public class Administrator1
    {
        private string adminName;
        private string emailAdress;
        private string passWord;

        public string EmailAdress
        {
            get
            {
                return emailAdress;
            }
            set
            {
                this.emailAdress = value;
            }
        }

        public string Password
        {
            get
            {
                return passWord; 
            }
            set
            {
                this.passWord = value;
            }
        }

        public string AdminName
        {
            get
            {
                return adminName;
            }
            set
            {
                this.adminName = value;
            }
        }

        public Administrator1()
        {
            this.adminName = "";
            this.emailAdress = "";
            this.passWord = "";
        }
    }
}
