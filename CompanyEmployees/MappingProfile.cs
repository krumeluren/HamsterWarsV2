using AutoMapper;
using Domain.Entities.Models;
using Shared.DataTransferObject;

namespace CompanyEmployees;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(c => c.name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Employee, EmployeeDto>()
            .ForMember(c => c.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(c => c.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(c => c.age, opt => opt.MapFrom(src => src.Age));
    }       
}
