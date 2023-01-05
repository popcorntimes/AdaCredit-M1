using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class EditClient
    {
        public static void Execute()
        {

            System.Console.WriteLine("Enter CPF (only numbers):");
            var document = System.Console.ReadLine();

            if (String.IsNullOrEmpty(document))
            {
                System.Console.WriteLine("Field must not be empty");
                System.Console.ReadKey();
                return;
            }

            Client? result = ClientRepository.GetByDoc(document);

            if (result == null)
            {
                System.Console.WriteLine("Client not available in the database");
                System.Console.ReadKey();
                return;

            }
            else
            {

                ClientRepository.Edit(result);

            }


            System.Console.ReadKey();

        }
    }
}
