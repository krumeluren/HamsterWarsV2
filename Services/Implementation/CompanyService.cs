using Contracts;
using Service.Contracts;

namespace Services.Implementation;
public class CompanyService : ICompanyService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;

    public CompanyService(IRepoManager repo, ILoggerManager logger)
    {
        _repo = repo;
        _logger = logger; 
    }
}
