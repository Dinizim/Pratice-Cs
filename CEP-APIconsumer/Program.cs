using CEP_APIconsumer.Interface;
using Refit;

namespace CEP_APIconsumer;

internal class Program
{
    static async Task Main(string[] args)
    {
        var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
        Console.WriteLine("Enter you CEP");
        string CepInfo = Console.ReadLine();

        var address = await cepClient.GetAddresAsync(CepInfo);

        Console.WriteLine(
                  $"CEP: {address.Cep}\n" +
                  $"Logradouro: {address.Logradouro}\n" +
                  $"Complemento: {address.Complemento}\n" +
                  $"Bairro: {address.Bairro}\n" +
                  $"Localidade: {address.Localidade}\n" +
                  $"UF: {address.Uf}\n" +
                  $"IBGE: {address.Ibge}\n" +
                  $"GIA: {address.Gia}\n" +
                  $"DDD: {address.Ddd}\n" +
                  $"SIAFI: {address.Siafi}");


    }
}
