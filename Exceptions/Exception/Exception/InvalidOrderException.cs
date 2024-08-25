using System;
using System.IO;

namespace ExceptionAPP.ExceptionClass;

public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message) : base(message)
    {
    }
}