using AutoMapper;
using Contracts;
using Domain.Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Services.Implementation;
public class EmployeeService : IEmployeeService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EmployeeService(IRepoManager repo, ILoggerManager logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDto> GetAll(bool trackChanges)
    {
        var employees = _repo.Company.GetAll(trackChanges);

        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return employeesDto;
    }
    
    public EmployeeDto GetById(Guid id, bool trackChanges)
    {
        var employees = _repo.Company.GetById(id, trackChanges);
        
        if (employees == null)
        {
            throw new EmployeeNotFoundException(id);
        }
        
        var employeesDto = _mapper.Map<EmployeeDto>(employees);
        return employeesDto;
    }

    public IEnumerable<EmployeeDto> GetEmployeesByCompany(Guid companyId, bool trackChanges)
    {
        var company = _repo.Company.GetById(companyId, trackChanges);
        if (company == null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var employees = _repo.Employee.GetEmployeesByCompany(companyId, trackChanges);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return employeesDto;
    }
}
