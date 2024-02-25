using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Program
    {
        static void ExibirDados()
        {
            DataTable dt = new DataTable();
            dt = DALBankSystem.GetAccounts();
            Console.WriteLine(dt);
        }
        static void Main(string[] args)
        {
           DALBankSystem.CriarBancoSQLite();
           DALBankSystem.CriarTabelaSQLite();

            bool opt = false;
            while (opt == false)
            {
                int choice = 0;
                Console.WriteLine("1 - criar dado");
                Console.WriteLine("2 - mostrar todos os dados");
                Console.WriteLine("3 - mostra um usuario");
                Console.WriteLine("4 - Editar um usuario");
                Console.WriteLine("5 - Deletar usuario");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        try
                        {
                            Client client = new Client("PEDRO", "54215857121", 29032004);
                            DALBankSystem.Add(client);
                            ExibirDados();


                        } catch (Exception ex) {
                            throw ex;
                        }
                        break;
                    case 2:
                        try
                        {
                            ExibirDados();

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        break;
                    case 3:
                        try
                        {
                            string cpf;
                            Console.Write("Digite o Cpf");
                            cpf = Console.ReadLine();

                            DataTable dt = new DataTable();
                            dt = DALBankSystem.GetAccount(cpf);

                            Console.WriteLine(dt);


                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        break;
                    case 4:
                        try
                        {
                            Client client = new Client("PEDRO", "12345678910", 29032005);
                            DALBankSystem.Update(client);
                            ExibirDados();


                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        break;
                    case 5:
                        try
                        {
                            string cpf;
                            Console.Write("Digite o Cpf");
                            cpf = Console.ReadLine();
                            DALBankSystem.Delete(cpf);
                            ExibirDados();


                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        break;
                }

            }


            




            /*int opt;
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
        }*/

        }
    }
}
