using AutoMapper;
using Repo.Contracts;
using Service.Contracts;
using Services.Implementation;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IHamsterService> _hamsterService;
    private readonly Lazy<IBattleService> _battleService;
    private readonly FileHandler _imageHandler;
    public ServiceManager(IRepoManager repoManager, ILoggerManager logger, IMapper mapper)
    {
        _hamsterService = new Lazy<IHamsterService>(() => new HamsterService(repoManager, logger, mapper));
        _battleService = new Lazy<IBattleService>(() => new BattleService(repoManager, logger, mapper));
        _imageHandler = new ImageHandler();
    }
    public IHamsterService HamsterService => _hamsterService.Value;
    public IBattleService BattleService => _battleService.Value;

    public FileHandler ImageHandler => _imageHandler;
}
