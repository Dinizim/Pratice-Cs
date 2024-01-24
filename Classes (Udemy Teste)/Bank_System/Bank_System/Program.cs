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
            */
            Banco banco = new Banco();
            banco.tranferir("51101252871", "12123", 60);

        }
   
    }
}
