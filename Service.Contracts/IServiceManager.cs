
namespace Core.Contracts.Service.Contracts;
public interface IServiceManager
{
    IHamsterService HamsterService { get; }
    IBattleService BattleService { get; }
    IFileHandler ImageHandler { get; }
}
