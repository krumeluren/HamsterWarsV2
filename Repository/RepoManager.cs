using Core.Contracts.Repo.Contracts;
using Infrastructure.Repository.Implementation;

namespace Infrastructure.Repository;

public class RepoManager : IRepoManager
{
    private readonly RepoContext _repoContext;
    private readonly Lazy<IHamsterRepo> _hamsterRepo;
    private readonly Lazy<IBattleRepo> _battleRepo;

    public RepoManager(RepoContext repoContext)
    {
        _repoContext = repoContext;
        _hamsterRepo = new Lazy<IHamsterRepo>(() => new HamsterRepo(_repoContext));
        _battleRepo = new Lazy<IBattleRepo>(() => new BattleRepo(_repoContext));
    }

    public IHamsterRepo Hamster => _hamsterRepo.Value;

    public IBattleRepo Battle => _battleRepo.Value;

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
