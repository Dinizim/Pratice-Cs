using Employee_management.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_management;
public abstract class Employee : ICalcilateSalary // != new Employee
{
    public string Name { get;}
    public string Last_Name { get; }
    public string Id { get; }

    // TODO: adicionar paramentros de validação para o metodo construtor usando execption
    protected Employee(string name,string last_name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(last_name))
        {
            throw new ArgumentException("Last name cannot be null or empty.", nameof(last_name));
        }

        
        Name = name;
        Last_Name = last_name;
        Id = ID_Generate();
    }


    public virtual double CalculateSalary()
    {
        return 00.00;
    }


    private static string ID_Generate()
    {
        return Guid.NewGuid().ToString().ToUpper().Substring(0, 5);
    }
}
