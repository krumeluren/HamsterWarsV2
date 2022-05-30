namespace Shared.DataTransferObject.Employee;
public record EmployeeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
}
