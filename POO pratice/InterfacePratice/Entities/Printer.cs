using InterfacePratice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePratice.Entities;

public class Printer : IPrinter
{
    public string Print(string Text)
    {
        return $"The text to be printed is :{Text} ";
    }
}
