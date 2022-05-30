namespace Shared.DataTransferObject.Employee;
public record EmployeeUpdateDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}
