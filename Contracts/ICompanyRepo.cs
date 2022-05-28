
using Domain.Entities.Models;

namespace Contracts;

public interface ICompanyRepo
{
    void CreateCompany(Company company);
    IEnumerable<Company> GetAll(bool trackChanges);
    Company GetById(Guid Id, bool trackChanges);
    IEnumerable<Company> GetByIds(IEnumerable<Guid> Ids, bool trackChanges);
}
