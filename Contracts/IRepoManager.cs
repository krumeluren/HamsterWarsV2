namespace Repo.Contracts;
public interface IRepoManager
{
    public IHamsterRepo Hamster { get; }
    public IBattleRepo Battle { get; }
    public void Save();
}
