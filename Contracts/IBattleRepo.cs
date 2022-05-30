using Domain.Entities.Models;
namespace Contracts;
public interface IBattleRepo
{
    IEnumerable<Battle> GetAll(bool trackChanges);
    Battle GetById(int id, bool trackChanges);
}
