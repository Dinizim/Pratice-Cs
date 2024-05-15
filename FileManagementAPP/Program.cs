namespace FileManagementAPP;

internal class Program
{
    static void Main(string[] args)
    {
            

            Console.WriteLine("---- FileManagementAPP ----");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your message: ");
            string message = Console.ReadLine();

            Console.Write("Please enter a title for your message: ");
            string Title = Console.ReadLine();


            var UserFile = new SaveFile(name,Title,Title,message);

            UserFile.CreateFolder(name);

            UserFile.CreateFile(
                UserFile.FolderPath,
                UserFile.FileContent,
                UserFile.FileTitle);


            Console.WriteLine("\nName: " + name);
            Console.WriteLine("Message : " + message);

            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }


