using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class Client : Banco
    {
        public string name { get; set; }
        public string cpf { get; set; }
        public int dd_mm_aa { get; set; }
        public float saldo { get; set; }
        public string aceess_key { get; set; }

        public Client(string name, string cpf, int dd_mm_aa)
        {
            this.name = name;
            this.cpf = cpf;
            saldo = 0;
            this.dd_mm_aa = dd_mm_aa;
            aceess_key = UUID_Generate();
        }
    }
}
