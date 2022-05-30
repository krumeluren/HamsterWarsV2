using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Services.Implementation;

public class HamsterService : IHamsterService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HamsterService(IRepoManager repo, ILoggerManager logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }

    public HamsterGetDto Create(HamsterPostDto entity, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HamsterGetDto> GetAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public HamsterGetDto GetById(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public HamsterGetDto GetRandom(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public HamsterGetDto Update(int id, HamsterPostDto entity, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
