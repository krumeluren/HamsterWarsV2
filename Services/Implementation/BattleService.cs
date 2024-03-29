﻿using AutoMapper;
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

        if(winner == null)
            throw new HamsterNotFoundException(battle.WinnerHamsterId);

        if (loser == null)
            throw new HamsterNotFoundException(battle.LoserHamsterId);

        winner.Games += 1;
        loser.Games += 1;
        winner.Wins += 1;
        loser.Losses += 1;

        _repo.Battle.CreateBattle(battleEntity);
        _repo.Save();
        _logger.LogInfo($"CREATE Battle created with ids: { battleEntity.Id}, winner: {winner.Id}, loser: {loser.Id}" );
        return _mapper.Map<BattleGetDto>(battleEntity);
    }

    public void Delete(int id, bool trackChanges)
    {
        var battle = _repo.Battle.GetById(id, trackChanges);
        if (battle == null)
            throw new BattleNotFoundException(id);
        
        _repo.Battle.DeleteBattle(battle);
        _repo.Save();
        _logger.LogInfo($"DELETE Battle with id: {id} was deleted.");
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
            throw new HamsterNotFoundException(hamsterId);

        var battles = _repo.Battle.GetAllByWinnerHamster(hamsterId, trackChanges);
        return _mapper.Map<IEnumerable<BattleGetDto>>(battles);
    }

    public BattleGetDto GetById(int id, bool trackChanges)
    {
        var battle = _repo.Battle.GetById(id, trackChanges);
        if (battle == null)
            throw new BattleNotFoundException(id);
        return _mapper.Map<BattleGetDto>(battle);
    }
}
