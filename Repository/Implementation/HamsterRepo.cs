using Contracts;
using Domain.Entities.Models;

namespace Repository.Implementation;

public class HamsterRepo : RepoBase<Hamster>, IHamsterRepo
{
    public HamsterRepo(RepoContext repoContext) : base(repoContext)
    {
    }

    public Hamster Create(Hamster hamster)
    {
        throw new NotImplementedException();
    }

    public void Delete(Hamster hamster)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hamster> GetAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Hamster GetById(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
