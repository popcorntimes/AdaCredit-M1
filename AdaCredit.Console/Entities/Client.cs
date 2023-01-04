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

        public bool IsActive { get; private set; }

        public Client(string name, long document)
        {
            this.Name = name;
            this.Document = document;
            this.Account = null;
        }

        public Client(string name, long document, Account account)
        {
            this.Name = name;
            this.Document = document;
            this.Account = account;
        }
    }
}
