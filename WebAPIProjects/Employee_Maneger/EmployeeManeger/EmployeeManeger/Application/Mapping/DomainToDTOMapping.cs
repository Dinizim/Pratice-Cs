using AutoMapper;
using EmployeeManeger.Domain.DTOs;
using EmployeeManeger.Domain.Models.EmployeeAggregate;

namespace EmployeeManeger.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
    }
}