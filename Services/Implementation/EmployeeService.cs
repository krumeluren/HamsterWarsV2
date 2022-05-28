using AutoMapper;
using Contracts;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
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

    public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateDto employee, bool trackChanges)
    {
        var company = _repo.Company.GetById(companyId, trackChanges);
        if (company == null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var employeeEntity = _mapper.Map<Employee>(employee);
        _repo.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        _repo.Save();
        
        var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
        return employeeDto;
    }

    public IEnumerable<EmployeeDto> GetAll(bool trackChanges)
    {
        var employees = _repo.Employee.GetAll(trackChanges);

        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        return employeesDto;
    }
    
    public EmployeeDto GetById(Guid id, bool trackChanges)
    {
        var employees = _repo.Employee.GetById(id, trackChanges);
        
        if (employees == null)
        {
            throw new EmployeeNotFoundException(id);
        }
        
        var employeesDto = _mapper.Map<EmployeeDto>(employees);
        return employeesDto;
    }

    public EmployeeDto GetEmployeeByCompany(Guid companyId, Guid employeeId, bool trackChanges)
    {
        var company = _repo.Company.GetById(companyId, trackChanges);
        if (company == null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var employee = _repo.Employee.GetEmployeeByCompany(companyId, employeeId, trackChanges);
        if (employee == null)
        {
            throw new EmployeeNotFoundException(employeeId);
        }
        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        return employeeDto;
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
