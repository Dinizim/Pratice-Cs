using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_management;
public class SalariedEmployee : Employee
{
    public double MonthlySalary { get; set; }

    public SalariedEmployee(string name, string last_name, double monthlysalary ) : base(name, last_name)
    {
        MonthlySalary = monthlysalary;
    }

    public override double CalculateSalary()
    {
        return MonthlySalary;
    }
}
