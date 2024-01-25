using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Bank_System
{
    public class Banco
    {
        public void CreateAccout(Client client)
        {
            List<Client> List_Client = DeserializeClient("Client.json");
            List_Client.Add(client);
            SerializeClient(List_Client,"Client.json");

        }
        public bool SearchAccout(string cpf_name)
        {
            List<Client> List_Client = DeserializeClient("Client.json");

            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(cpf_name))
                {
                    string key;
                    Console.WriteLine("CPF encontrado, Digite sua chave de acesso :");
                    key = Console.ReadLine();
                    if (Account.aceess_key.Equals(key))
                    {
                        SerializeClient(List_Client, "Client.json");
                        return true;      
                    }
                    else
                    {
                        Console.WriteLine("Chave Incorreta!");
                        
                    }
                }
                else
                {
                    Console.WriteLine("CPF não encontrado!");
                }

            }
            SerializeClient(List_Client, "Client.json");
            return false;
        }
        public void ViewAccout(string cpf_name)
        {
            List<Client> List_Client = DeserializeClient("Client.json");

            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(cpf_name))
                {
                    Console.WriteLine($"Saldo  R$: {Account.saldo}");
                    Console.WriteLine($"Nome : {Account.name}");
                    Console.WriteLine($"cpf : {Account.cpf}");
                    Console.WriteLine($"dd_mm_aa : {Account.dd_mm_aa}");
                    Console.WriteLine($"Chave de acesso : {Account.aceess_key}");
                    Console.ReadLine();

                    SerializeClient(List_Client, "Client.json");
                    int opt;
                    Console.WriteLine("Function");
                    Console.WriteLine("1 - Wihtdraw");
                    Console.WriteLine("2 - Deposit");
                    Console.WriteLine("3 - Transferir");
                    opt = int.Parse(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            float value_Withdraw;
                            Console.WriteLine("Digite o valor a ser sacado!");
                            value_Withdraw = float.Parse(Console.ReadLine());
                            Withdraw(Account.cpf,Account.name,value_Withdraw);
                            break;
                        case 2:
                            float value_deposit;
                            Console.WriteLine("Digite o valor a ser depositado");
                            value_deposit = float.Parse(Console.ReadLine());
                            Withdraw(Account.cpf, Account.name, value_deposit);
                            break;
                        case 3:
                            string cpf_destiny;
                            float value_Transfer;
                            Console.WriteLine("Digite o cpf da conta que ira receber o pagamento");
                            cpf_destiny = Console.ReadLine();
                            Console.WriteLine("Digite o valor a ser transferido");
                            value_Transfer = float.Parse(Console.ReadLine());
                            Withdraw(cpf_destiny, Account.cpf, value_Transfer);
                            break;

                    }
                }
            }
           
        }
       

        public void Deposit(string client_cpf, string client_name, float value)
        {
            List<Client> List_Client = DeserializeClient("Client.json");
            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(client_cpf) && Account.name.Equals(client_name))
                {
                    Account.saldo += value;
                    
                }
            }
            SerializeClient(List_Client, "Client.json");
        }

        public void Withdraw(string client_cpf, string client_name, float value)
        {
            List<Client> List_Client = DeserializeClient("Client.json");
            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(client_cpf) && Account.name.Equals(client_name))
                {
                    
                    if(Account.saldo > value)
                    {
                        Account.saldo -= value;
                    }
                    else
                    {
                        Console.WriteLine("Saldo indisponivel.");
                    }

                }
            }
            SerializeClient(List_Client, "Client.json");

        }
        public void tranferir(string destino_cpf , string saida_cpf,float value)
        {
            List<Client> List_Client = DeserializeClient("Client.json");
            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(saida_cpf))
                {

                    if (Account.saldo >= value)
                    {
                        Account.saldo -= value;
                    }
                    else
                    {
                        Console.WriteLine("Saldo indisponivel.");
                    }

                }
            }
           
            foreach (var Account in List_Client)
            {
                if (Account.cpf.Equals(destino_cpf))
                {
                    Account.saldo += value;

                }
            }
            SerializeClient(List_Client, "Client.json");
        }





        public string UUID_Generate()
        {
            return Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
        }


        public bool SerializeClient(List<Client> list, string path)
        {
            var strJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            return SaveFile(strJson, path);
        }

        public static List<Client> DeserializeClient(string strJson_Path)
        {

            var strJson = OpenFile(strJson_Path);
            return JsonConvert.DeserializeObject<List<Client>>(strJson);
        }

        private static string OpenFile(string path)
        {
            try
            {
                var Task_Json = path;
                using (StreamReader sr = new StreamReader(path))
                {
                    Task_Json = sr.ReadToEnd();
                }

                return Task_Json;

            }
            catch (Exception ex)
            {
                Console.WriteLine("arquivo não aberto, eu odeio minha vida");
                return "ERROR: " + ex.Message;
            }
        }
        private bool SaveFile(string strjson, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(strjson);
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("arquivo não salvo, eu odeio minha vida");
                return false;
            }
        }
    }
}
