
namespace Core.Domain.Entities.Models;

public class PlantCategory
{
    public int Id { get; set; }
    public DateTime TimeOfPost { get; set; } = DateTime.Now;

    public ICollection<Plant>? Plants { get; set; }
}
