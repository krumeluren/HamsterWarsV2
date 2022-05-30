using Contracts;
using Repository.Implementation;
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
    private readonly Lazy<IHamsterRepo> _hamsterRepo;
    private readonly Lazy<IBattleRepo> _battleRepo;

    public RepoManager(RepoContext repoContext)
    {
        _repoContext = repoContext;
        _companyRepo = new Lazy<ICompanyRepo>(() => new CompanyRepo(_repoContext));
        _employeeRepo = new Lazy<IEmployeeRepo>(() => new EmployeeRepo(_repoContext));
        _hamsterRepo = new Lazy<IHamsterRepo>(() => new HamsterRepo(_repoContext));
        _battleRepo = new Lazy<IBattleRepo>(() => new BattleRepo(_repoContext));
    }

    public ICompanyRepo Company => _companyRepo.Value;

    public IEmployeeRepo Employee => _employeeRepo.Value;

    public IHamsterRepo Hamster => _hamsterRepo.Value;

    public IBattleRepo Battle => _battleRepo.Value;

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
