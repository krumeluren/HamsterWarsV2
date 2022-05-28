namespace Shared.DataTransferObject;
public record CompanyCreateDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}
