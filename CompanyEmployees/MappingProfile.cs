using AutoMapper;
using Domain.Entities.Models;
using Shared.DataTransferObject.Company;
using Shared.DataTransferObject.Employee;

namespace CompanyEmployees;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Employee, EmployeeDto>()
            .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(c => c.Age, opt => opt.MapFrom(src => src.Age));

        CreateMap<CompanyCreateDto, Company>()
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<EmployeeCreateDto, Employee>()
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(c => c.Age, opt => opt.MapFrom(src => src.Age));

        CreateMap<CompanyUpdateDto, Company>().ReverseMap()
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name));
        
        CreateMap<EmployeeUpdateDto, Employee>();
        CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        
    }       
}
