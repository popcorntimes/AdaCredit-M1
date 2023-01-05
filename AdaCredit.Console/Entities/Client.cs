using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{

    public sealed class Client
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Account Account { get; set; } = null;

        public int IsActive { get; set; }

        public Client(string Name, string Document)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = null;
            this.IsActive = 1;
        }

        public Client(string Name, string Document, Account Account)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = Account;
            this.IsActive = 1;
        }
    }
}
