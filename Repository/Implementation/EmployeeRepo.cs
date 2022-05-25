using Contracts;
using Domain.Entities.Models;

namespace Repository;
public class EmployeeRepo : RepoBase<Employee>, IEmployeeRepo
{
    public EmployeeRepo(RepoContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
