using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.Employee;
public record EmployeeCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(90, ErrorMessage = "Name cannot be longer than 90 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Age is required")]
    [Range(1, 999, ErrorMessage = "Age must be between 1 and 999.")]
    public int Age { get; set; }
}
