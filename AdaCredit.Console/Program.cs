using AdaCredit.Console;
using Bogus.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdaCredit
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
            var employeeRepository = new EmployeeRepository();
            var loginScreen = new Login(employeeRepository);
            loginScreen.Show();
            
        }
    }
}