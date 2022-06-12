namespace Core.Domain.Entities.Exceptions;

public sealed class BattleNotFoundException : NotFoundException
{
    public BattleNotFoundException(int id) : base($"Battle with id {id} not found")
    {
    }
}
