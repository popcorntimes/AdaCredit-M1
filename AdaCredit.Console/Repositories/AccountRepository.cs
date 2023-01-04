using AdaCredit.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace AdaCredit
{
    public static class AccountRepository
    {
        private static List<Account> Accounts { get; set; } = new List<Account>();

        static AccountRepository()
        {
            try
            {
                Read();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        public static bool Add()
        {
            Read();
            bool isCreated = false;
            string number;

            do
            {
                number = new Faker().Random.ReplaceNumbers("######");
                isCreated = IsCreated(number);
            } while(isCreated);

            Account acc = new Account(number);

            Accounts.Add(acc);

            Save();

            return true;


        }

        public static Account? GetNewAccount()
        {
            Read();
            bool isCreated = false;
            string number;

            do
            {
                number = new Faker().Random.ReplaceNumbers("######");
                isCreated = IsCreated(number);
            } while (isCreated);

            Account acc = new Account(number);

            Accounts.Add(acc);

            Save();

            return acc;
        }
        
        public static Account? GetByNumber(string number) => Accounts.FirstOrDefault(account => account.Number == number);

        public static bool IsCreated(string number) => Accounts.Any(account => account.Number == number);

        public static void Start()
        {
            Read();
        }
        public static void Read()
        {
            FileManager file = new FileManager("accounts.csv");
            Accounts = file.CsvReader<Account>();

        }

        public static void Save()
        {
            FileManager file = new FileManager("accounts.csv");

            file.CsvWriter(Accounts);
        }
    }
}
