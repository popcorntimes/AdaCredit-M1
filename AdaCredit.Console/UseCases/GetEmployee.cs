using AdaCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdaCredit
{
    internal class GetEmployee
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

                EmployeeRepository.Print(result);

            }


            System.Console.ReadKey();

        }
    }
}
