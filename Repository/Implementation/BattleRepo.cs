using Core.Domain.Entities.Models;
using Core.Contracts.Repo.Contracts;

namespace Infrastructure.Repository.Implementation;
public class BattleRepo : RepoBase<Battle>, IBattleRepo
{
    public BattleRepo(RepoContext repoContext) : base(repoContext)
    {
    }
    
    public Battle CreateBattle(Battle battle)
    {
        Create(battle);
        return battle;
    }

    public void DeleteBattle(Battle battle)
    {
        Delete(battle);
    }

    public IEnumerable<Battle> GetAll(bool trackChanges)
    {
        return FindAll(trackChanges).ToList();
    }

    public Battle GetById(int id, bool trackChanges)
    {
        return FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
