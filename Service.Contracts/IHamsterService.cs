using Shared.DataTransferObject;
namespace Service.Contracts;
public interface IHamsterService
{
    /// <summary>
    /// Gets all the hamsters
    /// </summary>
    IEnumerable<HamsterGetDto> GetAll(bool trackChanges);
    /// <summary>
    /// Get one hamster by id
    /// </summary>
    HamsterGetDto GetById(int id, bool trackChanges);
    /// <summary>
    /// Get a random hamster
    /// </summary>
    HamsterGetDto GetRandom(bool trackChanges);
    /// <summary>
    /// Add a new hamster to the database
    /// </summary>
    HamsterGetDto Create(HamsterPostDto entity, bool trackChanges);
    /// <summary>
    /// Update a hamster in the database
    /// </summary>
    HamsterGetDto Update(int id, HamsterPostDto entity, bool trackChanges);
    /// <summary>
    /// Delete a hamster from the database
    /// </summary>
    void Delete(int id, bool trackChanges);
}
