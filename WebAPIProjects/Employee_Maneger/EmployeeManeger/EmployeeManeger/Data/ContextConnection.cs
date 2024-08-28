using EmployeeManeger.Models.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManeger.Data;

public class ContextConnection : DbContext
{
    public ContextConnection(DbContextOptions<ContextConnection> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}