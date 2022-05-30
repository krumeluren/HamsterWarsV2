using Shared.DataTransferObject.Employee;

namespace Shared.DataTransferObject.Company;
public record CompanyUpdateDto
{
    public string Name { get; init; }
    public IEnumerable<EmployeeCreateDto>? Employees { get; init; }
}
