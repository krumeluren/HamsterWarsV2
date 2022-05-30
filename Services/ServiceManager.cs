using AutoMapper;
using Contracts;
using Service.Contracts;
using Services.Implementation;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<IHamsterService> _hamsterService;
    private readonly Lazy<IBattleService> _battleService;

    public ServiceManager(IRepoManager repoManager, ILoggerManager logger, IMapper mapper)
    {
        _companyService = new Lazy<ICompanyService>(() =>  new CompanyService(repoManager, logger, mapper));
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repoManager, logger, mapper));
        _hamsterService = new Lazy<IHamsterService>(() => new HamsterService(repoManager, logger, mapper));
        _battleService = new Lazy<IBattleService>(() => new BattleService(repoManager, logger, mapper));
    }
    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;

    public IHamsterService HamsterService => _hamsterService.Value;

    public IBattleService BattleService => _battleService.Value;
}
