using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.Console.UseCases
{
    internal class StartProcessing
    {
        public static void Execute()
        {

            TransactionRepository.Read();
            System.Console.ReadKey();
        }
    }
}
