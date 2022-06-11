namespace Shared.DataTransferObject.Battle;

public record BattleGetDto
{
    public int Id { get; set; }
    public DateTime TimeOfPost { get; set; }
    public int? WinnerHamsterId { get; set; }
    public int? LoserHamsterId { get; set; }
}
