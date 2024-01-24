using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes__Udemy_Teste_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instancia() da classe carro e definindo suas propiedades com o metodo construtor
            Carro carro = new Carro(4,Cor.Preto,"Gol G6");

            //chamando suas propieddaes
            Console.WriteLine($"o modelo do carro é um {carro.modelo} com {carro.portas} portas, com a cor {carro.cor}");

            //chamando seus metodos
            Console.WriteLine(carro.ligar());
            Console.WriteLine(carro.andar());
            Console.WriteLine(carro.desligar());
        }
    }
}
