using EmployeeManeger.Models.EmployeeAggregate;

namespace EmployeeManeger.Data;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ContextConnection _context;

    public EmployeeRepository(ContextConnection context)
    {
        _context = context;
    }

    public void Add(Employee employee)
    {
        _context.Add(employee);
        _context.SaveChanges();
    }

    public List<Employee> Get()
    {
        return _context.Employees.ToList();
    }
}