using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class ShowActiveEmployees
    {
        public static void Execute()
        {
            EmployeeRepository.PrintAllActives();
            System.Console.ReadKey();
        }

    }
}
