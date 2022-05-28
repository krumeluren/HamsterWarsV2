
namespace Domain.Entities.Exceptions;

public sealed class CompanyCollectionBadRequestException : BadRequestException
{
    public CompanyCollectionBadRequestException() : base("Company collection is null")
    {
    }
}

