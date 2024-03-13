namespace ExceptionTest;

internal class Program
{
    
        static void Main(string[] args)
        {

            Console.WriteLine(
                          "Validador de senha \n" +
                          "- Crie uma senha com no máximo 5 digitos \n"+
                          "- Ela não pode conter espaços e numeros\n");
            Console.WriteLine("Digite sua senha :");
            string senha = Console.ReadLine();
            try
            {  
                Test(senha);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR :"+ ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR :" + ex.Message);
        }
            finally
            {
                Console.WriteLine("Obrigado por usar meu programa!");
            }
        }

        private static void Test(string senha)
        {
            bool containNumbers = senha.Any(char.IsDigit);
            if (string.IsNullOrEmpty(senha) || senha.Length > 5 || containNumbers)
                throw new ArgumentException("A senha não atende os caracteres especificados");

        }
        
    }
  

