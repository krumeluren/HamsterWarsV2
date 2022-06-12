namespace Core.Domain.Entities.Exceptions;

public sealed class HamsterNotFoundException : NotFoundException
{
    public HamsterNotFoundException(int id) : base($"Hamster with id {id} not found")
    {
    }
}

