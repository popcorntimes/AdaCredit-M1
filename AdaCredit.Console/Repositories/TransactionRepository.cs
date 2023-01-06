using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class TransactionRepository
    {
        private static List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public static Client TargetClient { get; set; } = null;
        public static Client OriginClient { get; set; } = null;

        private static readonly decimal taxTED = 5.0m;

        private static readonly decimal taxDOC = 1.0m;


        public static void Read()
        {
            FileManager file = new FileManager(0);
            var pathList = file.GetFilePaths();
            var nameList = file.GetFileNames();
            for(int i = 0; i < pathList.Count; i++)
            {
                Transactions = file.TransactionReader<Transaction>(pathList[i]);
                System.Console.WriteLine($"{pathList[i]}");
                System.Console.WriteLine($"Processing transactions from {nameList[i]}");
                Start();
            }


        }

        public static void FailedTransactions()
        {
            FileManager file = new FileManager(2);
            var pathList = file.GetFilePaths();
            var nameList = file.GetFileNames();
            for (int i = 0; i < pathList.Count; i++)
            {
                Transactions = file.TransactionReader<Transaction>(pathList[i]);
                System.Console.WriteLine($"{pathList[i]}");
                System.Console.WriteLine($"Showing failed transactions from {nameList[i]}");
                Start();
            }
        }

        public static bool CheckAccounts(Transaction tr)
        {

            Client? cli1 = ClientRepository.GetExistingActive(tr.TargetNumber, tr.TargetBranch, tr.TargetBankCode);
            Client? cli2 = ClientRepository.GetExistingActive(tr.OriginNumber, tr.OriginBranch, tr.OriginBankCode);
            if(cli1 == null || cli2 == null) {
                return false;
            }
            if (cli1.Document.Equals(cli2.Document))
            {
                return false;
            }
            TargetClient = cli1;
            OriginClient = cli2;

            return true;
            

        }

        public static void Start() {

            bool hasAccounts = false;
            bool hasBalance = false;
            bool canTED = false;
            decimal tax = 0.0m;
            decimal transactionTax = 0.0m;

            foreach (Transaction t in Transactions)
            {

                hasAccounts = CheckAccounts(t);
                if(!hasAccounts)
                {
                    System.Console.WriteLine("Failed transaction, invalid account(s)");
                    continue;
                }

                if(t.Type == "TEF")
                {
                    canTED = CheckTEF(t);
                    if (!canTED)
                    {
                        System.Console.WriteLine("Failed transaction, can't TEF between different banks");
                        continue;
                    }

                    hasBalance = HasBalance(t.Value);
                    if (!hasBalance)
                    {
                        System.Console.WriteLine("Failed TEF transaction, not enough funds");
                        continue;
                    }

                }

                if(t.Type == "TED")
                {
                    tax = taxTED;
                    hasBalance = HasBalance(t.Value + tax);
                    if (!hasBalance)
                    {
                        System.Console.WriteLine("Failed TED transaction, not enough funds");
                        continue;
                    }
                }

                if (t.Type == "DOC")
                {
                    if(0.01m * t.Value > 5.0m)
                    {
                        transactionTax = 5.0m;
                    }
                    else
                    {
                        transactionTax = 0.01m * t.Value;
                    }
                    tax = taxDOC + transactionTax;
                    hasBalance = HasBalance(t.Value + tax);
                    if (!hasBalance)
                    {
                        System.Console.WriteLine("Failed DOC transaction, not enough funds");
                        continue;
                    }
                }

                System.Console.WriteLine("Another validation TBA");
                
            }

            System.Console.WriteLine("\r\n");

        }

        public static bool HasBalance(decimal value)
        {
            if(OriginClient.Account.Balance - value < 0)
            {
                return false;
            }
            return true;

        }

        public static bool CheckTEF(Transaction tr)
        {
            if(tr.OriginBankCode != tr.TargetBankCode)
            {
                return false;
            }

            return true;
        }

        public static void CheckAllAccounts()
        {

            foreach(Transaction t in Transactions)
            {
                System.Console.WriteLine(CheckAccounts(t));

            }
        }
    }
}
