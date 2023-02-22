
using Core.Domain.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Models;

public class Plant
{
    public int Id { get; set; }
    public DateTime TimeOfPost { get; set; } = DateTime.Now;

    public ICollection<PlantCategory>? PlantCategories { get; set; }
}
