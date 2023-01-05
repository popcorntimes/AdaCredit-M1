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

        public static void Show(Client client)
        {
            System.Console.WriteLine(client.Name);
            System.Console.WriteLine(client.Document);
            System.Console.WriteLine(client.Account.Number);
            System.Console.WriteLine(client.Account.Branch);
            System.Console.WriteLine(client.Account.Balance);
        }

        public static int IsActive(Client client) => client.IsActive;


        public static void Deactivate(Client client)
        {
            client.IsActive = 0;
            Save();
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
