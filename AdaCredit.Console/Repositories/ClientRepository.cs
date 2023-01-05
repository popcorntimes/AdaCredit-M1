using AdaCredit.Console;
using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static void Generate(int qt)
        {
            string name;
            string document;
            for(int i = 0; i < qt; i++)
            {
                name = new Faker("pt_BR").Name.FullName();
                document = new Faker().Random.ReplaceNumbers("###########");
                Add(name, document);
            }

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
        
        public static string MaskNumber (string number)
        {
            string mask;
            string accNumber;
            string digit;
            accNumber = number.Substring(0, 5);
            digit = number.Substring(5);
            mask = accNumber + "-" + digit;
            return mask;
        }

        public static void EditName(Client client)
        {
            string name;
            System.Console.Write("Enter new name: ");
            name = System.Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                System.Console.WriteLine("Name should not be empty");
                System.Console.ReadKey();
                System.Console.Clear();
                return;
            }

            client.Name = name;

            Save();

            System.Console.WriteLine("Name updated");

        }
        public static void EditDocument(Client client)
        {
            string document;
            System.Console.Write("Enter new CPF (only numbers):");
            document = System.Console.ReadLine();
            if (string.IsNullOrEmpty(document))
            {
                System.Console.WriteLine("CPF should not be empty");
                System.Console.ReadKey();
                System.Console.Clear();
                return;
            }
            if (document.Length != 11)
            {
                System.Console.WriteLine("CPF must have 11 digits");
                System.Console.ReadKey();
                return;
            }

            client.Document = document;

            Save();

            System.Console.WriteLine("CPF updated");



        }


        public static void Edit(Client client)
        {
            System.Console.Write("Enter 0 to edit name and 1 to edit document: ");
            string? option = System.Console.ReadLine();
            if(option.Equals("0"))
            {
                EditName(client);
            } else if(option.Equals("1"))
            {
                EditDocument(client);
            } else
            {
                System.Console.Write("Incorrect option");
            }
        }

        public static void Print(Client client)
        {
            string status = "None";
            System.Console.WriteLine($"Name: {client.Name}");
            System.Console.WriteLine($"Document: {client.Document}");
            System.Console.WriteLine($"Account number: {MaskNumber(client.Account.Number)}");
            System.Console.WriteLine($"Account branch: {client.Account.Branch}");
            System.Console.WriteLine($"Account balance: R${client.Account.Balance}");
            if(client.Inactive.Equals("x"))
            {
                status = "Inactive";
            }
            else
            {
                status = "Active";
            }
            System.Console.WriteLine($"Status: {status}");
        }

        public static string IsActive(Client client) => client.Inactive;

        public static List<Client> AllActives() => Clients.Where(client => !client.Inactive.Equals("x")).ToList();
        public static List<Client> AllInactives() => Clients.Where(client => client.Inactive.Equals("x")).ToList();

        public static void PrintAllActives()
        {

            List<Client> clis = AllActives();

            if (clis.Count != 0)
            {
                foreach (Client cli in clis)
                {
                    string status;
                    System.Console.WriteLine($"Name: {cli.Name}");
                    System.Console.WriteLine($"Document: {cli.Document}");
                    System.Console.WriteLine($"Account number: {MaskNumber(cli.Account.Number)}");
                    System.Console.WriteLine($"Account branch: {cli.Account.Branch}");
                    System.Console.WriteLine($"Account balance: R${cli.Account.Balance}");
                    if (cli.Inactive.Equals("x"))
                    {
                        status = "Inactive";
                    }
                    else
                    {
                        status = "Active";
                    }
                    System.Console.WriteLine($"Status: {status}\r\n");
                }
                
            } else
            {
                System.Console.WriteLine("No active client");
            }

            



        }
        public static void PrintAllInactives()
        {
            List<Client> clis = AllInactives();


            if (clis.Count != 0)
            {
                foreach (Client cli in clis)
                {

                    System.Console.WriteLine($"Name: {cli.Name}");
                    System.Console.WriteLine($"Document: {cli.Document}");
                    System.Console.WriteLine($"Account number: {MaskNumber(cli.Account.Number)}");
                    System.Console.WriteLine($"Account branch: {cli.Account.Branch}");
                    System.Console.WriteLine($"Account balance: R${cli.Account.Balance}\r\n");
                }

            }
            else
            {
                System.Console.WriteLine("No inactive client");
            }



        }


        public static void Deactivate(Client client)
        {
            client.Inactive = "x";
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
