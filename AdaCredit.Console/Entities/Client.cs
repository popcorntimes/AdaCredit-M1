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

        public string Inactive { get; set; }

        public Client(string Name, string Document, string Inactive = null)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = null;
            this.Inactive = Inactive;
        }

        public Client(string Name, string Document, Account Account, string Inactive = null)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = Account;
            this.Inactive = Inactive;
        }
    }
}
