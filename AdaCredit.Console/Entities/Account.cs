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
        public string Number { get; set; }
        public string Branch { get; set; }

        public decimal Balance { get; set; }

        public int IsActive { get; set; }

        public Account()
        {
            this.Number = new Faker().Random.ReplaceNumbers("######");
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0.0m;
            this.IsActive = 1;



        }

        public Account(string accountNumber)
        {
            this.Number = accountNumber;
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0.0m;
            this.IsActive = 1;


        }
    }
}