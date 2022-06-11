using Domain.Entities.Models;

namespace Repo.Contracts;
public interface IBattleRepo
{
    IEnumerable<Battle> GetAll(bool trackChanges);
    Battle GetById(int id, bool trackChanges);
    Battle CreateBattle(Battle battle);
    void DeleteBattle(Battle battle);
}
