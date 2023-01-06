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
            //ClientRepository.Generate(100);
            ClientRepository.Start();
            EmployeeRepository.Start();
            Login.Show();
            Menu.Show();


        }
    }
}