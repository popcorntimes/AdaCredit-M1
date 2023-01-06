using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class AddNewClient
    {
        public static void Execute()
        {
            System.Console.WriteLine("Enter name:");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Enter CPF (only numbers):");
            var document = System.Console.ReadLine();

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(document))
            {
                System.Console.WriteLine("Fields must not be empty");
                System.Console.ReadKey();
                return;
            }

            if(document.Length != 11)
            {
                System.Console.WriteLine("CPF must have 11 digits");
                System.Console.ReadKey();
                return;
            }

            var result = ClientRepository.Add(name, document);

            if (result)
                System.Console.WriteLine("Client registered");
            else
                System.Console.WriteLine("Register failed");

            System.Console.ReadKey();

        }
    }
}
