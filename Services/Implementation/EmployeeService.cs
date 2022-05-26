using AutoMapper;
using Contracts;
using Service.Contracts;

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
}
