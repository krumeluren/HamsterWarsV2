using Contracts;
using Domain.Entities.Models;
namespace Repository.Implementation;
public class BattleRepo : RepoBase<Battle>,  IBattleRepo
{
    public BattleRepo(RepoContext repoContext) : base(repoContext)
    {
    }
    public IEnumerable<Battle> GetAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Battle GetById(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
