namespace Employee_management;

internal class Program
{
    static void ShowEmployee(Employee employee)
    {
        Console.WriteLine(
            $"Name: {employee.Name}\n" +
            $"LastName: {employee.Last_Name}\n" +
            $"Id: {employee.Id}\n" +
            $"Payment: {employee.CalculateSalary()}\n");
    }

    static void Main(string[] args)
    {
        Employee Marcelo = new SalariedEmployee("Marcelo","Guilherme", 4000.00);
        Employee Douglas = new HourlyEmployee("Douglas", "Miguel", 6 , 60);
        ShowEmployee(Marcelo);
        ShowEmployee(Douglas);
    }

    


}
