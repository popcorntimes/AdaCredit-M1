using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace AdaCredit
{
    public sealed class Account
    {
        private readonly string DEFAULT_BRANCH_NUMBER = "0001";
        public string Number { get; private set; }
        public string Branch { get; private set; }

        public decimal Balance { get; private set; }

        public bool IsActive { get; private set; }

        public Account()
        {
            this.Number = new Faker().Random.ReplaceNumbers("#####-#");
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0;
        }

        public Account(string accountNumber)
        {
            this.Number = accountNumber;
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0;
        }
    }
}