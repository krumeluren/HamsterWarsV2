using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Contracts;

namespace Repository.Implementation;

public class HamsterRepo : RepoBase<Hamster>, IHamsterRepo
{
    public HamsterRepo(RepoContext repoContext) : base(repoContext)
    {
    }

    public Hamster CreateHamster(Hamster hamster)
    {
        Create(hamster);
        return hamster;
    }

    public void DeleteHamster(Hamster hamster)
    {
        Delete(hamster);
    }

    public IEnumerable<Hamster> GetAll(bool trackChanges)
    {
        return FindAll(trackChanges).ToList();
    }

    public Hamster GetById(int id, bool trackChanges)
    {
        return FindByCondition(h => h.Id.Equals(id), trackChanges)
            .Include(e => e.BattlesLost)
            .Include(e => e.BattlesWon)
            .SingleOrDefault();
    }
}
