using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Domain.Entities.Models;
public class Hamster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? FavFood { get; set; }
    public string? Loves { get; set; }
    public string? ImgName { get; set; }
    public int Wins { get; set; } = 0;
    public int Losses { get; set; } = 0;
    public int Games { get; set; } = 0;

    [InverseProperty("WinnerHamster")]
    public ICollection<Battle>? BattlesWon {get; private set; }
    [InverseProperty("LoserHamster")]
    public ICollection<Battle>? BattlesLost { get; set; }
}
