using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace HamsterWarsBlazorUI.Models;
public class HamsterForm
{
    [Required(ErrorMessage = "A name is required")]
    [MaxLength(15, ErrorMessage = "Name is too long (15 characters max)")]
    [MinLength(4, ErrorMessage = "Name is too short (4 characters min)")]
    public string Name { get; set; }
    [Required(ErrorMessage = "An age is required")]
    [Range(0, 1000, ErrorMessage = "Age must be between 0 and 1000")]
    public int Age { get; set; }
    [MaxLength(30, ErrorMessage = "Favourite Food is too long (30 characters max)")]
    public string? FavFood { get; set; }
    [Required(ErrorMessage = "Favourite Activity is required")]
    [MaxLength(100, ErrorMessage = "Favourite Activity is too long (100 characters max)")]
    public string? Loves { get; set; }
    [Required(ErrorMessage = "Image is required")]
    public string? ImgName { get; set; }
    public string? ImgData { get; set; }
}
