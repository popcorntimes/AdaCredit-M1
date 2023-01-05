using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class ShowInactiveClients
    {
        public static void Execute()
        {
            ClientRepository.PrintAllInactives();
            System.Console.ReadKey();
        }
    }
}
