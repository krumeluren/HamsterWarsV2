using AutoMapper;
using Core.Contracts.Repo.Contracts;
using Core.Contracts.Service.Contracts;

namespace Services.Implementation;

public class PlantCategoryService : IPlantCategoryService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public PlantCategoryService(IRepoManager repo, ILoggerManager logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }
}
