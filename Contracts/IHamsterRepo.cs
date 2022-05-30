
using Domain.Entities.Models;

namespace Contracts;
public interface IHamsterRepo
{
    /// <summary>
    /// Get all hamsters
    /// </summary>
    IEnumerable<Hamster> GetAll(bool trackChanges);
    /// <summary>
    /// Get one hamster by id
    /// </summary>
    Hamster GetById(int id, bool trackChanges);
    /// <summary>
    /// Add a new hamster to the database
    /// </summary>
    Hamster Create(Hamster hamster);
    /// <summary>
    /// Delete the hamster from the database
    /// </summary>
    /// <param name="hamster"></param>
    void Delete(Hamster hamster);
    
}
