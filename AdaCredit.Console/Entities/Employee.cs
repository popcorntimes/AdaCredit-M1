using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    public class Employee
    {

        public string Username { get; set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public DateTime? LastLoginAt { get; set; }
        public int IsActive { get; set; }

        public Employee(string Username, string Password, string Salt, DateTime? LastLoginAt = null,int IsActive = 1)
        {
            this.Username = Username;
            this.Password = Password;
            this.Salt = Salt;
            this.LastLoginAt = LastLoginAt;
            this.IsActive = IsActive;

        }

        public bool ChangePassword(string password, string salt)
        {
            this.Password = password;
            this.Salt = salt;
            return true;
        }

        

    }
}
