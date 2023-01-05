using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.Console.UseCases
{
    internal class DeactivateClient
    {
        public static void Execute()
        {

            System.Console.WriteLine("Enter CPF (only numbers):");
            var document = System.Console.ReadLine();

            if (String.IsNullOrEmpty(document))
            {
                System.Console.WriteLine("Field must not be empty, try again");
                System.Console.ReadKey();
                return;
            }
            ClientRepository.Read();
            Client? result = ClientRepository.GetByDoc(document);

            if (result == null)
            {
                System.Console.WriteLine("Client not available in the database");
                System.Console.ReadKey();
                return;

            }
            if (ClientRepository.IsActive(result) == 0)
            {
                System.Console.WriteLine("Client already deactivated");
                System.Console.ReadKey();
                return;

            }


            ClientRepository.Deactivate(result);
            System.Console.WriteLine("Client deactivated");



            System.Console.ReadKey();

        }
    }
}
