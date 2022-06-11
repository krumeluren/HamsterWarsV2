namespace Shared.DataTransferObject.Battle;

public record BattlePostDto
{
    public int WinnerHamsterId { get; set; }
    public int LoserHamsterId { get; set; }
}
