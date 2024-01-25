using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            /* add Account
            Client client = new Client("nicollas3", "51101252871", 12022004);
            Banco banco = new Banco();
            banco.CreateAccout(client);
            */
            /* view Account
            string name = "nicollas3";
            Banco banco = new Banco();
            banco.ViewAccout(name);
            

            Banco banco = new Banco();
            banco.tranferir("51101252871", "12123", 60);
            */
            int opt;
            Console.WriteLine("Bank");
            Console.WriteLine("1 - Create Account");
            Console.WriteLine("2 - login");
            opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    string name;
                    string cpf;
                    int date;

                    Console.WriteLine("Create Account");
                    Console.WriteLine("Digite seu nome completo");
                    name = Console.ReadLine();
                    Console.WriteLine("Digite o seu CPF");
                    cpf = Console.ReadLine();
                    Console.Write("Digite o seu aniversário agora");
                    date = int.Parse(Console.ReadLine());

                    Client client = new Client(name,cpf,date);
                    Console.WriteLine($"sua chave de acesso é {client.aceess_key}");

                    Banco banco = new Banco();
                    banco.CreateAccout(client);

                    break;
            }



        }
   
    }
}
