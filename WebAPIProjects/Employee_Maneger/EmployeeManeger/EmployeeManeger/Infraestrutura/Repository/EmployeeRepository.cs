using EmployeeManeger.Domain.DTOs;
using EmployeeManeger.Domain.Models.EmployeeAggregate;
using EmployeeManeger.Infraestrutura.Data;

namespace EmployeeManeger.Infraestrutura.Repository;

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

    public Employee? get(int id)
    {
        return _context.Employees.Find(id);
    }

    public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
    {
        return _context.Employees.Select(x => new EmployeeDTO
        {
            Id = x.id,
            NameEmployee = x.name,
            Photo = x.photo
        }).Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
    }
}