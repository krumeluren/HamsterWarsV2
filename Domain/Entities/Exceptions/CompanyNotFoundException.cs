
namespace Domain.Entities.Exceptions;

public sealed class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(Guid Id) : base($"Company with Id: {Id} not found.")
    {
        
    }
}
