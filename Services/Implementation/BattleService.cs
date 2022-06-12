using AutoMapper;
using Core.Contracts.Service.Contracts;
using Core.Domain.Entities.Models;
using Core.Shared.DataTransferObject.Battle;
using Core.Contracts.Repo.Contracts;
using Core.Domain.Entities.Exceptions;

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

    public BattleGetDto Create(BattlePostDto battle, bool trackChanges)
    {
        var battleEntity = _mapper.Map<Battle>(battle);
        var winner = _repo.Hamster.GetById(battle.WinnerHamsterId, trackChanges);
        var loser = _repo.Hamster.GetById(battle.LoserHamsterId, trackChanges);
        winner.Games += 1;
        loser.Games += 1;
        winner.Wins += 1;
        loser.Losses += 1;

        _repo.Battle.CreateBattle(battleEntity);
        _repo.Save();
        return _mapper.Map<BattleGetDto>(battleEntity);
    }

    public void Delete(int id, bool trackChanges)
    {
        var battle = _repo.Battle.GetById(id, trackChanges);
        _repo.Battle.DeleteBattle(battle);
        _repo.Save();
    }

    public IEnumerable<BattleGetDto> GetAll(bool trackChanges)
    {
        var battles = _repo.Battle.GetAll(trackChanges);
        return _mapper.Map<IEnumerable<BattleGetDto>>(battles);
    }

    public IEnumerable<BattleGetDto> GetAllByWinnerHamsterId(int hamsterId, bool trackChanges)
    {
        var hamster = _repo.Hamster.GetById(hamsterId, trackChanges);
        if (hamster == null)
        {
            throw new HamsterNotFoundException(hamsterId);
        }
        var battles = _repo.Battle.GetAll(trackChanges).Where(x => x.WinnerHamsterId == hamsterId);
        return _mapper.Map<IEnumerable<BattleGetDto>>(battles);
    }

    public BattleGetDto GetById(int id, bool trackChanges)
    {
        var battle = _repo.Battle.GetById(id, trackChanges);
        return _mapper.Map<BattleGetDto>(battle);
    }
}
