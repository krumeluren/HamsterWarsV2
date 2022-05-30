
using Domain.Entities.Models;

namespace Contracts;
public interface IEmployeeRepo
{
    /// <returns>List of all employees in database</returns>
    IEnumerable<Employee> GetAll(bool trackChanges);

    /// <returns>List of employees where the companyId column value equals the parameter companyId</returns>
    IEnumerable<Employee> GetEmployeesByCompany(Guid companyId, bool trackChanges);

    /// <returns>A single employee where companyId column value equals parameter companyId</returns>
    Employee GetEmployeeByCompany(Guid companyId, Guid employeeId, bool trackChanges);

    /// <returns>A single employee where companyId column value equals parameter companyId</returns>
    Employee GetById(Guid Id, bool trackChanges);

    /// <summary>
    /// Create an employee with a specified companyId
    /// </summary>
    void CreateEmployeeForCompany(Guid companyId, Employee employee);

    /// <summary>
    /// Delete the employee
    /// </summary>
    void DeleteEmployee(Employee employee);
}
