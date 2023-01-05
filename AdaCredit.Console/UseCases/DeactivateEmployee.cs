using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class DeactivateEmployee
    {
        public static void Execute()
        {
            System.Console.WriteLine("Enter username:");
            var username = System.Console.ReadLine();

            if (String.IsNullOrEmpty(username))
            {
                System.Console.WriteLine("Field must not be empty");
                System.Console.ReadKey();
                return;
            }
            Employee? result = EmployeeRepository.GetByUser(username);

            if (result == null)
            {
                System.Console.WriteLine("Client not available in the database");
                System.Console.ReadKey();
                return;

            }
            if (EmployeeRepository.IsActive(result) == "x")
            {
                System.Console.WriteLine("Employee already deactivated");
                System.Console.ReadKey();
                return;

            }

            EmployeeRepository.Deactivate(result);
            System.Console.WriteLine("Employee deactivated");


            System.Console.ReadKey();
        }

    }
}
