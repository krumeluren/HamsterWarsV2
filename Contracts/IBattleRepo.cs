using Core.Domain.Entities.Models;

namespace Core.Contracts.Repo.Contracts;
public interface IBattleRepo
{
    IEnumerable<Battle> GetAll(bool trackChanges);
    IEnumerable<Battle> GetAllByWinnerHamster(int id, bool trackChanges);
    Battle GetById(int id, bool trackChanges);
    Battle CreateBattle(Battle battle);
    void DeleteBattle(Battle battle);
}
