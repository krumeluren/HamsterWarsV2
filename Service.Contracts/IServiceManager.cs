
namespace Service.Contracts;
public interface IServiceManager
{
    IHamsterService HamsterService { get; }
    IBattleService BattleService { get; }
    FileHandler ImageHandler { get; }
}
