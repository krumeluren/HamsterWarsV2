using AutoMapper;
using Domain.Entities.Models;
using Shared.DataTransferObject;

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
            .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name));
            
    }       
}
