using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models;
public class Battle
{
    public int Id { get; set; }
    public DateTime TimeOfPost { get; set; } = DateTime.Now;
    public int? WinnerHamsterId { get; set; }
    
    [ForeignKey("WinnerHamsterId")]
    public virtual Hamster? WinnerHamster { get; set; }
    public int? LoserHamsterId { get; set; }
    [ForeignKey("LoserHamsterId")]
    public virtual Hamster? LoserHamster { get; set; }
}
