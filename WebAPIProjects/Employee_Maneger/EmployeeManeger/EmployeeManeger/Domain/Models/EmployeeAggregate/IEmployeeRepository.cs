using EmployeeManeger.Domain.DTOs;

namespace EmployeeManeger.Domain.Models.EmployeeAggregate;

public interface IEmployeeRepository
{
    void Add(Employee employee);

    List<EmployeeDTO> Get(int pageNumber, int pageQuantity);

    Employee? get(int id);
}