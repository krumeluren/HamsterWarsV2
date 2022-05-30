

namespace Shared.DataTransferObject;

public record BattlePostDto
{
    public int WinnerHamsterId { get; set; }
    public int LoserHamsterId { get; set; }
}
