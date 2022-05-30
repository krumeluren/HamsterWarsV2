namespace Contracts;
public interface IRepoManager
{
    public ICompanyRepo Company { get; }
    public IEmployeeRepo Employee { get; }
    public IHamsterRepo Hamster { get; }
    public IBattleRepo Battle { get; }
    public void Save();
}
