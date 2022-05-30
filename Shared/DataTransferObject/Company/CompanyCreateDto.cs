using Shared.DataTransferObject.Employee;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject.Company;
public record CompanyCreateDto
{
    [Required(ErrorMessage = "Company Name is required")]
    [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; init; }
    public IEnumerable<EmployeeCreateDto>? Employees { get; init; }
}
