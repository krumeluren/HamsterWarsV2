

namespace Domain.Entities.Exceptions;

public class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException() : base("Collection count mismatch comparing to Ids")
    {
    }
}
