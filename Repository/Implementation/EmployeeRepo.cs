using Contracts;
using Domain.Entities.Models;

namespace Repository;
public class EmployeeRepo : RepoBase<Employee>, IEmployeeRepo
{
    public EmployeeRepo(RepoContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Employee> GetAll(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }

    public Employee GetById(Guid Id, bool trackChanges)
    {
        return FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();
    }

    public IEnumerable<Employee> GetEmployeesByCompany(Guid companyId, bool trackChanges)
    {
        return FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(c => c.Name)
                .ToList();
    }
}
