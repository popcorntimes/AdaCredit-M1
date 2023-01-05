using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdaCredit
{
    internal class ShowActiveClients
    {
        public static void Execute()
        {
            ClientRepository.PrintAllActives();
            System.Console.ReadKey();
        }
    }
}
