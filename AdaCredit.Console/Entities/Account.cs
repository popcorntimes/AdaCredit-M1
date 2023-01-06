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
        private readonly string DEFAULT_BANK_CODE = "777";
        public string BankCode { get; set; }
        public string Number { get; set; }
        public string Branch { get; set; }

        public decimal Balance { get; set; }

        //public int IsAActive { get; set; }

        public Account()
        {
            this.BankCode = this.DEFAULT_BANK_CODE;
            this.Number = new Faker().Random.ReplaceNumbers("######");
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0.0m;
            //this.IsAActive = 1;



        }

        public Account(string accountNumber)
        {
            this.BankCode = this.DEFAULT_BANK_CODE;
            this.Number = accountNumber;
            this.Branch = this.DEFAULT_BRANCH_NUMBER;
            this.Balance = 0.0m;
            //this.IsAActive = 1;


        }


        public Account(string BankCode, string Number, string Branch)
        {
            this.BankCode = BankCode;
            this.Number = Number;
            this.Branch = Branch;
        }
    }
}