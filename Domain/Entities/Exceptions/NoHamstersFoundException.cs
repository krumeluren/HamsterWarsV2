namespace Core.Domain.Entities.Exceptions;
public class NoHamstersFoundException : NotFoundException
{
    public NoHamstersFoundException(string message) : base(message)
    {
    }
}
