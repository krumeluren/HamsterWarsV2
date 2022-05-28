
using Domain.Entities.Models;

namespace Contracts;
public interface IEmployeeRepo
{
    IEnumerable<Employee> GetAll(bool trackChanges);
    IEnumerable<Employee> GetEmployeesByCompany(Guid companyId, bool trackChanges);
    Employee GetEmployeeByCompany(Guid companyId, Guid employeeId, bool trackChanges);
    Employee GetById(Guid Id, bool trackChanges);

    void CreateEmployeeForCompany(Guid companyId, Employee employee);
}
