using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class AddNewEmployee
    {
        public static void Execute()
        {
            System.Console.WriteLine("Enter username:");
            var username = System.Console.ReadLine();

            System.Console.WriteLine("Enter password:");
            var password = System.Console.ReadLine();


            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("Fields must not be empty");
                System.Console.ReadKey();
                return;
            }

            var result = EmployeeRepository.Add(username, password);

            if (result)
                System.Console.WriteLine("Employee registered");
            else
                System.Console.WriteLine("Register failed");

            System.Console.ReadKey();

        }
    }
}
