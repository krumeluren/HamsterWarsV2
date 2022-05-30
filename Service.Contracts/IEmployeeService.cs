using Shared.DataTransferObject.Employee;

namespace Service.Contracts;
public interface IEmployeeService
{
    /// <summary>
    /// Get all the employees of the company if the company exist
    /// </summary>
    /// <returns>A list of employees</returns>
    IEnumerable<EmployeeDto> GetEmployeesByCompany(Guid companyId, bool trackChanges);

    /// <summary>
    /// Get an employee of the company if the company exist
    /// </summary>
    /// <returns>An employee</returns>
    EmployeeDto GetEmployeeByCompany(Guid companyId, Guid employeeId, bool trackChanges);

    /// <returns>A list of all employees in the database</returns>
    IEnumerable<EmployeeDto> GetAll(bool trackChanges);
    
    /// <returns>An employee </returns>
    EmployeeDto GetById(Guid id, bool trackChanges);

    /// <summary>
    /// Add an employee beloning to a company to the database if the company exist
    /// </summary>
    EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateDto employee, bool trackChanges);

    /// <summary>
    /// Delete an employee beloning to a company if the company exist
    /// </summary>
    void DeleteEmployeeInCompany(Guid companyId, Guid employeeId, bool trackChanges);

    void UpdateEmployeeInCompany(Guid companyId, Guid employeeId, EmployeeUpdateDto employee, bool companyTrackChanges, bool employeeTrackChanges);
}
