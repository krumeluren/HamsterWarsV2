using System.ComponentModel.DataAnnotations;

namespace Core.Shared.DataTransferObject.Hamster;

public record HamsterPutDto
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
    public string? ImgName { get; set; }

    public int? Wins { get; set; }
    public int? Losses { get; set; }
    public int? Games { get; set; }
}
