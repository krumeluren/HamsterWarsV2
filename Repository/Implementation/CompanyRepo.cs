using Contracts;
using Domain.Entities.Models;

namespace Repository;
public class CompanyRepo : RepoBase<Company>, ICompanyRepo
{
    public CompanyRepo(RepoContext databaseFactory)
        : base(databaseFactory)
    {
    }

    public IEnumerable<Company> GetAll(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }

    public Company GetById(Guid Id, bool trackChanges)
    {
        return FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();
    }
}
