using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit;

namespace AdaCredit
{
    public static class Login
    {

        public static void Show()
        {
            var isFirstAccess = false;
            var loggedIn = false;

            System.Console.Clear();
            System.Console.WriteLine("Welcome to Ada Credit");
            System.Console.WriteLine("You must login to continue");

            do
            {

                System.Console.Write("Enter the username: ");
                var username = System.Console.ReadLine();

                System.Console.Write("Enter the password: ");
                var password = System.Console.ReadLine();

                isFirstAccess = username.Equals("user", StringComparison.InvariantCultureIgnoreCase)
                           && password.Equals("pass", StringComparison.InvariantCultureIgnoreCase);
                if (isFirstAccess)
                {
                    System.Console.WriteLine("First access detected");
                    System.Console.Write("Enter the new username: ");
                    username = System.Console.ReadLine();
                    System.Console.Write("Enter the new password: ");
                    password = System.Console.ReadLine();
                    loggedIn = EmployeeRepository.Add(username, password);
                   
                } else
                {
                    loggedIn = EmployeeRepository.TryLogin(username, password);
                }

            } while (!loggedIn);

            
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}
