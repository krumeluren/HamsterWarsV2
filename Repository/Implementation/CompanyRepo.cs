using Contracts;
using Domain.Entities.Models;

namespace Repository;
public class CompanyRepo : RepoBase<Company>, ICompanyRepo
{
    public CompanyRepo(RepoContext databaseFactory)
        : base(databaseFactory)
    {
    }

    public void CreateCompany(Company company)
    {
        Create(company);
    }

    public void DeleteCompany(Company company)
    {
        Delete(company);
    }

    public IEnumerable<Company> GetAll(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }

    public Company GetById(Guid Id, bool trackChanges)
    {
        return FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();
    }

    public IEnumerable<Company> GetByIds(IEnumerable<Guid> Ids, bool trackChanges)
    {
        return FindByCondition(c => Ids.Contains(c.Id), trackChanges).ToList();
    }
}
