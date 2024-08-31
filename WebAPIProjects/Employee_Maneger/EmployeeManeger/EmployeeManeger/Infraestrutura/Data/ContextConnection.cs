using EmployeeManeger.Domain.Models.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManeger.Infraestrutura.Data;

public class ContextConnection : DbContext
{
    public ContextConnection(DbContextOptions<ContextConnection> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}