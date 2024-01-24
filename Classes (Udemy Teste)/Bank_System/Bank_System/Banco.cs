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
        public void ViewAccout(string client_name)
        {
            List<Client> List_Client = DeserializeClient("Client.json");

            foreach (var Account  in List_Client)
            {
                if (Account.name.Equals(client_name))
                {
                    Console.WriteLine($"Saldo  R$: {Account.saldo}");
                    Console.WriteLine($"Nome : {Account.name}");
                    Console.WriteLine($"cpf : {Account.cpf}");
                    Console.WriteLine($"dd_mm_aa : {Account.dd_mm_aa}");
                    Console.WriteLine($"Chave de acesso : {Account.aceess_key}");
                }
            }
        }
       

        public void deposit(string client_cpf, string client_name, float value)
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
                Console.WriteLine("json não aberto, eu odeio minha vida");
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
                Console.WriteLine("json não salvo, eu odeio minha vida");
                return false;
            }
        }
    }
}
