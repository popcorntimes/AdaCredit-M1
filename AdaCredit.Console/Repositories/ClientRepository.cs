using AdaCredit.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    public static class ClientRepository
    {
        private static List<Client> Clients { get; set; } = new List<Client>();

        static ClientRepository()
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

        public static void Start()
        {
            Read();
        }

        public static bool Add(string name, string document)
        {
            if (Clients.Any(x => x.Document.Equals(document)))
            {
                System.Console.WriteLine("This client is already registered!");
                System.Console.ReadKey();

                return false;
            }
            var entity = new Client(name, document, AccountRepository.GetNewAccount());

            //var entity = new Client(client.Name, client.Document);
            Clients.Add(entity);
            Save();

            return true;
        }

        public static Client? GetByDoc(string? document) => Clients.FirstOrDefault(client => client.Document == document);

        public static void Print(Client client)
        {
            System.Console.WriteLine("Name: ", client.Name);
            System.Console.WriteLine("Document: ", client.Document);
            System.Console.WriteLine("Account number: ", client.Account.Number);
            System.Console.WriteLine("Account branch: ", client.Account.Branch);
            System.Console.WriteLine("Account balance: ", client.Account.Balance);
        }


        public static void Read()
        {
            FileManager file = new FileManager("clients.csv");
            Clients = file.CsvReader<Client>();

        }

        public static void Save()
        {
            FileManager file = new FileManager("clients.csv");

            file.CsvWriter(Clients);
        }

        

    }
}
