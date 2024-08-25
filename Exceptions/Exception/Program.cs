using ExceptionAPP.ExceptionClass;

try
{
    OrderProcess(-10);
}
catch (InvalidOrderException ex)
{
    Console.WriteLine($"{ex.Source} : {ex.Message} ,\n {ex.StackTrace}");
    throw;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"{ex.Source} : {ex.Message} ,\n {ex.StackTrace}");
    throw;
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Source} : {ex.Message} ,\n {ex.StackTrace}");
    throw;
}
finally
{
    Console.WriteLine("Finally block");
}

void OrderProcess(int v)
{
    if (v <= 0)
    {
        throw new InvalidOrderException("The order value it must be bigger than 0 ");
    }
    Console.WriteLine("Order placed successfully");
}