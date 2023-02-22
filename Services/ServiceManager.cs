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
    private readonly Lazy<IPlantCategoryService> _plantCategoryService;
    private readonly Lazy<IPlantService> _plantService;

    public ServiceManager(IRepoManager repoManager, ILoggerManager logger, IMapper mapper)
    {
        _hamsterService = new Lazy<IHamsterService>(() => new HamsterService(repoManager, logger, mapper));
        _battleService = new Lazy<IBattleService>(() => new BattleService(repoManager, logger, mapper));
        _imageHandler = new Lazy<IFileHandler>(() => new ImageHandler(logger));
        _plantCategoryService = new Lazy<IPlantCategoryService>(() => new PlantCategoryService(repoManager, logger, mapper));
        _plantService = new Lazy<IPlantService>(() => new PlantService(repoManager, logger, mapper));
        
    }
    public IHamsterService HamsterService => _hamsterService.Value;
    public IBattleService BattleService => _battleService.Value;
    public IFileHandler ImageHandler => _imageHandler.Value;

    public IPlantCategoryService PlantCategoryService => _plantCategoryService.Value;

    public IPlantService PlantService => _plantService.Value;
}
