namespace Calculator;

internal class Program
{
    static void Main(string[] args)
    {

        Menu();
    }

    static void Menu()
    {
        Console.Clear();


        Console.WriteLine("Calculator" +
            "What you want to do?\n" +
            "1 - ADD\n" +
            "2 - Subtraction\n" +
            "3 - Division\n" +
            "4 - Multiplication\n" +
            "5 - exit\n" + "----------\n" +
            "Select an option:\n");


        int res = int.Parse(Console.ReadLine());

        switch (res)
        {
            case 1: Sum(); break;
            case 2: Sub(); break;
            case 3: Multi(); break;
            case 4: Div(); break;
            case 5: System.Environment.Exit(0);break;
            default: Menu(); break;
        }

    }
    static void Sum()
    {
        float value1, value2;
        Console.Write("Enter the first value :\n");
        value1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second value :\n");
        value2 = int.Parse(Console.ReadLine());

        Console.Write($"The sum of {value1} and {value2} is equal to {value1 + value2}");
    }
    static void Sub()
    {
        float value1, value2;

        Console.Write("Enter the first value :\n");
        value1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second value :\n");
        value2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"The sub of {value1} and {value2} is equal to {value1 - value2}");
    }
    static void Multi()
    {
        float value1, value2;

        Console.Write("Enter the first value :\n");
        value1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second value :\n");
        value2 = int.Parse(Console.ReadLine());
        Console.WriteLine($"The sub of {value1} and {value2} is equal to {value1 * value2}");
    }
    static void Div()
    {
        float value1, value2;

        Console.Write("Enter the first value :\n");
        value1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second value :\n");
        value2 = int.Parse(Console.ReadLine());

        Console.WriteLine($"The sub of {value1} and {value2} is equal to {value1 / value2}");
    }
}
