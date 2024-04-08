namespace InterfacePratice;
using InterfacePratice.Interface;
using InterfacePratice.Entities;

internal class Program
{
    static void Main(string[] args)
    {
        var Printer = new Printer();
        var Copier = new Copier();

        Console.Write("\n\n");

        Console.Write(Printer.Print("I love you\n"));
        Console.Write(Copier.Xerox("Me too...\n"));

        Console.Write("\n\n");

        var PrinterCopier = new PrinterCopier();
        Console.Write(PrinterCopier.Print("I love you\n"));
        Console.Write(PrinterCopier.Xerox("Me too...\n"));

        Console.Write("\n\n");

        CopyDoc(PrinterCopier, "I love you\n");
        CopyDoc(Copier, "Me too...\n");

        Console.Write("\n\n");
    }

    public static void CopyDoc(ICopier copier, string Text)
    {
        Console.Write(copier.Xerox(Text));
    }
}
