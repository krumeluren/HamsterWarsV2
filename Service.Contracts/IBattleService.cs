using Core.Shared.DataTransferObject.Battle;

namespace Core.Contracts.Service.Contracts;
public interface IBattleService
{
    IEnumerable<BattleGetDto> GetAll(bool trackChanges);
    IEnumerable<BattleGetDto> GetAllByWinnerHamsterId(int hamsterId, bool trackChanges);
    BattleGetDto GetById(int id, bool trackChanges);
    BattleGetDto Create(BattlePostDto battle, bool trackChanges);
    void Delete(int id, bool trackChanges);
}
