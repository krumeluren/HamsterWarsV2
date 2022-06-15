namespace Presentation.HamsterWarsBlazorUI.Models;

public class Match
{
    public int Id { get; set; }

    public int WinnerHamsterId { get; set; }
    public int LoserHamsterId { get; set; }

    public DateTime TimeOfPost { get; set; }
    
    public Hamster? WinnerHamster { get; set; }
    public Hamster? LoserHamster { get; set; }
}
