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

            int opt;
            bool exit = false;
            string name;
            string cpf;
            int date;

            do
            {
                Console.Clear();
                Console.WriteLine("Bank");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - Create Account");
                Console.WriteLine("2 - login");

                opt = int.Parse(Console.ReadLine());
                
                Banco banco = new Banco();
                switch (opt)
                {

                    case 1:


                        Console.WriteLine("Create Account");

                        Console.WriteLine("Digite seu nome completo");
                        name = (Console.ReadLine());
                        name = name.ToUpper();

                        Console.WriteLine("Digite o seu CPF");
                        cpf = Console.ReadLine();

                        Console.Write("Digite o seu aniversário agora");
                        date = int.Parse(Console.ReadLine());

                        Client client = new Client(name, cpf, date);
                        Console.WriteLine($"sua chave de acesso é {client.aceess_key}");


                        banco.CreateAccout(client);

                        break;

                    case 2:


                        Console.WriteLine("Login Account");

                        Console.WriteLine("Digite o seu CPF");
                        cpf = Console.ReadLine();


                        bool acessado = banco.SearchAccout(cpf);
                        if (acessado)
                        {
                            banco.ViewAccout(cpf);
                        }

                        break;

                    case 0:
                        exit = true;
                        break;
                }


            } while (!exit);
        }
   
    }
}
