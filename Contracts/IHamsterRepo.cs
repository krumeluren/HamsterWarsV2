
using Domain.Entities.Models;

namespace Repo.Contracts;
public interface IHamsterRepo
{
    IEnumerable<Hamster> GetAll(bool trackChanges);
    Hamster GetById(int id, bool trackChanges);
}
