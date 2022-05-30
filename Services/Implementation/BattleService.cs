using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Services.Implementation;
public class BattleService : IBattleService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BattleService(IRepoManager repo, ILoggerManager logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }
}
