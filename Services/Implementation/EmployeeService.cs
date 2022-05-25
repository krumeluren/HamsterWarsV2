using Contracts;
using Service.Contracts;

namespace Services.Implementation;
public class EmployeeService : IEmployeeService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;

    public EmployeeService(IRepoManager repo, ILoggerManager logger)
    {
        _repo = repo;
        _logger = logger;
    }
}
