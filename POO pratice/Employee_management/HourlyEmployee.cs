using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_management;
public class HourlyEmployee : Employee
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public HourlyEmployee(string name, string last_name, int hoursworked, double hourlyrate ) : base(name, last_name)
    {
        HourlyRate = hourlyrate;
        HoursWorked = hoursworked;
    }
    public override double CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}
