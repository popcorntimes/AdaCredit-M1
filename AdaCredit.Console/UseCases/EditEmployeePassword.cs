using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class EditEmployeePassword
    {
        public static void Execute()
        {
            System.Console.WriteLine("Enter username:");
            var username = System.Console.ReadLine();

            if (String.IsNullOrEmpty(username))
            {
                System.Console.WriteLine("Field must not be empty, try again");
                System.Console.ReadKey();
                return;
            }
            Employee? result = EmployeeRepository.GetByUser(username);

            if (result == null)
            {
                System.Console.WriteLine("Employee not available in the database");
                System.Console.ReadKey();
                return;

            }
            else
            {

                EmployeeRepository.EditPassword(result);

            }


            System.Console.ReadKey();

        }
    }
}
