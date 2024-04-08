using InterfacePratice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePratice.Entities;

public class PrinterCopier : IPrinter,ICopier
{
    public string Xerox(string Text)
    {
        return $"The text to be copied is :{Text}";
    }

    public string Print(string Text)
    {
        return $"The text to be printed is :{Text} ";
    }
}
