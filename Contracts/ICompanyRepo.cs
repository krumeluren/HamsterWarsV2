
using Domain.Entities.Models;

namespace Contracts;

public interface ICompanyRepo
{
    void Create(Company company);
    IEnumerable<Company> GetAll(bool trackChanges);
    Company GetById(Guid Id, bool trackChanges);
    void Update(Company company);
    void Delete(Company company);

}
