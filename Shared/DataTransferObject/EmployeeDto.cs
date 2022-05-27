namespace Shared.DataTransferObject;
public record EmployeeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
}
