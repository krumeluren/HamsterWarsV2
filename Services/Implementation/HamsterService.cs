using AutoMapper;
using Core.Contracts.Repo.Contracts;
using Core.Contracts.Service.Contracts;
using Core.Domain.Entities.Exceptions;
using Core.Domain.Entities.Models;
using Core.Shared.DataTransferObject.Hamster;

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

    public HamsterGetDto Create(HamsterPostDto entity, bool trackChanges) //TODO: trackchanges remove?
    {
        var hamster = _mapper.Map<Hamster>(entity);
        _repo.Hamster.CreateHamster(hamster);
        _repo.Save();
        return _mapper.Map<HamsterGetDto>(hamster);
    }

    public void Delete(int id, bool trackChanges)
    {
        var hamster = _repo.Hamster.GetById(id, trackChanges);

        if (hamster == null)
        {
            throw new HamsterNotFoundException(id);
        }
        _repo.Hamster.DeleteHamster(hamster);
        _repo.Save();
    }

    public IEnumerable<HamsterGetDto> GetAll(bool trackChanges)
    {
        var hamsters = _repo.Hamster.GetAll(trackChanges);
        return _mapper.Map<IEnumerable<HamsterGetDto>>(hamsters);
    }

    public HamsterGetDto GetById(int id, bool trackChanges)
    {
        var hamster = _repo.Hamster.GetById(id, trackChanges);
        if (hamster == null)
        {
            throw new HamsterNotFoundException(id);
        }
        return _mapper.Map<HamsterGetDto>(hamster);
    }

    public HamsterGetDto GetRandom(bool trackChanges)
    {
        var allHamsters = _repo.Hamster.GetAll(trackChanges);
        if (allHamsters.Count() == 0)
        {
            throw new InvalidOperationException("No hamsters found");
        }
        var hamster = allHamsters.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        return _mapper.Map<HamsterGetDto>(hamster);
    }

    public IEnumerable<HamsterGetDto> TopLosers(int count, bool trackChanges)
    {
        var hamsters = _repo.Hamster.GetAll(trackChanges);
        var topLosers = hamsters.OrderByDescending(x => x.Losses).Take(count);
        return _mapper.Map<IEnumerable<HamsterGetDto>>(topLosers);
    }

    public IEnumerable<HamsterGetDto> TopWinners(int count, bool trackChanges)
    {
        var hamsters = _repo.Hamster.GetAll(trackChanges);
        var topWinners = hamsters.OrderByDescending(x => x.Wins).Take(count);
        return _mapper.Map<IEnumerable<HamsterGetDto>>(topWinners);
    }

    public HamsterGetDto Update(int id, HamsterPutDto entity, bool trackChanges)
    {
        var hamster = _repo.Hamster.GetById(id, trackChanges);
        if (hamster == null)
        {
            throw new HamsterNotFoundException(id);
        }
        _mapper.Map(entity, hamster);
        _repo.Save();
        return _mapper.Map<HamsterGetDto>(hamster);
    }
}
