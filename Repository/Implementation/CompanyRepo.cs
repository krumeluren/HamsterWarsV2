using Contracts;
using Domain.Entities.Models;

namespace Repository;
public class CompanyRepo : RepoBase<Company>, ICompanyRepo
{
    public CompanyRepo(RepoContext databaseFactory)
        : base(databaseFactory)
    {
    }   
}
