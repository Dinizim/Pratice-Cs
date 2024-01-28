using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=f1c59617a4c34ffab01230839242701&q=Sao%20Paulo&aqi=no");

            // Aguarde a conclusão da leitura do conteúdo
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }
    }
}
