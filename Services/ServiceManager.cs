using AutoMapper;
using Contracts;
using Service.Contracts;
using Services.Implementation;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;
    public ServiceManager(IRepoManager repoManager, ILoggerManager logger, IMapper mapper)
    {
        
        _companyService = new Lazy<ICompanyService>(() =>  new CompanyService(repoManager, logger, mapper));
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repoManager, logger, mapper));
    }
    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}
