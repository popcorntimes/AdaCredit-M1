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
        public string Name { get; private set; }
        public long Document { get; private set; }
        public Account Account { get; private set; } = null;

        public int IsActive { get; private set; }

        public Client(string Name, long Document, int IsActive = 1)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = null;
            this.IsActive = IsActive;
        }

        public Client(string Name, long Document, Account Account, int IsActive = 1)
        {
            this.Name = Name;
            this.Document = Document;
            this.Account = Account;
            this.IsActive = IsActive;
        }
    }
}
