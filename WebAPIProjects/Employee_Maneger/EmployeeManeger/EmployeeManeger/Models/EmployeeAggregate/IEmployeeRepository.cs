﻿namespace EmployeeManeger.Models.EmployeeAggregate;

public interface IEmployeeRepository
{
    void Add(Employee employee);

    List<Employee> Get();
}