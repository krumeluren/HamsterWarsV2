using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.Hamster;
public record HamsterPostDto
{
    [MaxLength(20, ErrorMessage = "Property 'Name' must be between 4 and 20 characters long")]
    [MinLength(4, ErrorMessage = "Property 'Name' must be between 4 and 20 characters long")]
    public string Name { get; set; }

    [Range(0, 100, ErrorMessage = "Property 'Age' must be between 0 and 100")]
    public int Age { get; set; }

    [MaxLength(100, ErrorMessage = "Property 'FavFood' cannot be longer than 100 characters")]
    public string? FavFood { get; set; }

    [MaxLength(100, ErrorMessage = "Property 'Loves' cannot be longer than 100 characters")]
    public string? Loves { get; set; }

    [MaxLength(100, ErrorMessage = "Property 'ImgName' cannot be longer than 100 characters")]
    [Required(ErrorMessage = "Property 'ImgName' is required")]
    public string ImgName { get; set; }

    [Required(ErrorMessage = "Property 'ImgData' is required (Base64 string of image file)")]
    public string ImgData { get; set; }
}
