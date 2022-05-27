namespace Domain.Entities.Exceptions;

public sealed class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid Id) : base($"Employee with id {Id} not found")
    {
    }
}
