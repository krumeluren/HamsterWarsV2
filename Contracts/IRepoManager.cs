using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface IRepoManager
{
    public ICompanyRepo Company { get; }
    public IEmployeeRepo Employee { get; }

    public void Save();
}
