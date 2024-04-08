using InterfacePratice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePratice.Entities;

public class Copier : ICopier
{
    public string Xerox(string Text)
    {
        return $"The text to be copied is : {Text}";
    }
}
