using AutoMapper;
using Core.Contracts.Repo.Contracts;
using Core.Contracts.Service.Contracts;
using Services.Implementation;

namespace Services;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IHamsterService> _hamsterService;
    private readonly Lazy<IBattleService> _battleService;
    private readonly Lazy<IFileHandler> _imageHandler;
    public ServiceManager(IRepoManager repoManager, Core.Contracts.Repo.Contracts.ILoggerManager logger, IMapper mapper)
    {
        _hamsterService = new Lazy<IHamsterService>(() => new HamsterService(repoManager, logger, mapper));
        _battleService = new Lazy<IBattleService>(() => new BattleService(repoManager, logger, mapper));
        _imageHandler = new Lazy<IFileHandler>(() => new ImageHandler(logger));
    }
    public IHamsterService HamsterService => _hamsterService.Value;
    public IBattleService BattleService => _battleService.Value;
    public IFileHandler ImageHandler => _imageHandler.Value;
}
