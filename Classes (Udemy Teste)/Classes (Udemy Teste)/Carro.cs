using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes__Udemy_Teste_
{
    public class Carro
    {
        public int portas;
        //Cor é uma enumaração (enum)
        public Cor cor;
        public bool ligado;
        public string modelo;

        //metodo construtor
        public Carro(int portas, Cor cor, string modelo)
        {
            this.portas = portas;
            this.cor = cor;
            this.modelo = modelo;
        }

        public string ligar()
        {
            ligado = true;
            return ("o carro está ligado");
        }
        public string desligar()
        {
            ligado = false;
            return ("o carro foi desligado");
        }
        public string andar()
        {
           
            return ("o carro esta andando");
        }
    }
}
