using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class RepoManager : IRepoManager
{
    private readonly RepoContext _repoContext;
    private readonly Lazy<ICompanyRepo> _companyRepo;
    private readonly Lazy<IEmployeeRepo> _employeeRepo;
    
    public RepoManager(RepoContext repoContext)
    {
        _repoContext = repoContext;
        _companyRepo = new Lazy<ICompanyRepo>(() => new CompanyRepo(_repoContext));
        _employeeRepo = new Lazy<IEmployeeRepo>(() => new EmployeeRepo(_repoContext));
    }

    public ICompanyRepo Company => _companyRepo.Value;

    public IEmployeeRepo Employee => _employeeRepo.Value;

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
