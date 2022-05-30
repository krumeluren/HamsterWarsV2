
namespace Shared.DataTransferObject;
public record HamsterPostDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string? FavFood { get; set; }
    public string? Loves { get; set; }
    public string? ImgName { get; set; }
}
