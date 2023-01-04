using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit
{
    internal class AddNewClient
    {
        public static void Execute()
        {
            System.Console.WriteLine("Digite o Nome:");
            var name = System.Console.ReadLine();

            System.Console.WriteLine("Digite o CPF (sem formatação):");
            var document = long.Parse(System.Console.ReadLine());

            var client = new Client(name, document);

            var repository = new ClientRepository();
            
            var result = repository.Add(client);

            if (result)
                System.Console.WriteLine("Cliente cadastrado com sucesso!");
            else
                System.Console.WriteLine("Falha ao cadastrar novo cliente!");

            System.Console.ReadKey();
        }
    }
}
