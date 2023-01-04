using AdaCredit.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    public class ClientRepository
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

        public bool Add(Client client)
        {
            
            if (Clients.Any(x => x.Document.Equals(client.Document)))
            {
                System.Console.WriteLine("This client is already registered!");
                System.Console.ReadKey();

                return false;
            }
            //var entity = new Client(client.Name, client.Document, AccountRepository.GetAccount());

            var entity = new Client(client.Name, client.Document);
            Clients.Add(entity);

            Save();

            return true;
        }


        private static void Read()
        {
            FileManager file = new FileManager("clients.csv");
            Clients = file.CsvReader<Client>();

        }

        private static void Save()
        {
            FileManager file = new FileManager("clients.csv");

            file.CsvWriter(Clients);
        }

        

    }
}
