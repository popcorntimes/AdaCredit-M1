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
        public string Inactive { get; set; }

        public Employee(string Username, string Password, string Salt, DateTime? LastLoginAt = null, string Inactive = null)
        {
            this.Username = Username;
            this.Password = Password;
            this.Salt = Salt;
            this.LastLoginAt = LastLoginAt;
            this.Inactive = Inactive;

        }

        public bool ChangePassword(string password, string salt)
        {
            this.Password = password;
            this.Salt = salt;
            return true;
        }

        

    }
}
