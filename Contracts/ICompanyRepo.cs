
using Domain.Entities.Models;

namespace Contracts;

public interface ICompanyRepo
{
    void Create(Company company);
    IEnumerable<Company> GetAll(bool trackChanges);
    Company GetById(int id);
    void Update(Company company);
    void Delete(Company company);

}
