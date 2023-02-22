namespace Core.Contracts.Repo.Contracts;
public interface IRepoManager
{
    public IHamsterRepo Hamster { get; }
    public IBattleRepo Battle { get; }
    public IPlantRepo Plant { get; }
    public IPlantCategoryRepo PlantCategory { get; }
    public void Save();
}
