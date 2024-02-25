using System.Reflection.Metadata;

namespace TextEditor;

internal class Program
{
    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("What do you want to do?\n"
            +"1 - Open file\n"
            +"2 - Create new file\n"
            +"0 - Exit");
        short res = short.Parse(Console.ReadLine());

        switch (res)
        {
            case 0: System.Environment.Exit(0); break;
            case 1: Open(); break;
            case 2: Edit(); break;
            default: Menu(); break;
        }

    }
    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Qual caminho do arquivo?");
        string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

    }
    static void Edit()
    {
        Console.Write("Enter your text:     (ESC to exit)\n");
        Console.Write("----------------------------------\n");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;

        } while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text);

    }
    static void Save(string text)
    {
        Console.Clear();
        var path = Directory.GetCurrentDirectory();
        
        using(var file = new StreamWriter(path))
        {
            file.Write(text);
        }
        Menu();
    }

       
}
