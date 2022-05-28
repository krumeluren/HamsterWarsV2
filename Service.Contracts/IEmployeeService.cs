using Shared.DataTransferObject;

namespace Service.Contracts;
public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetEmployeesByCompany(Guid companyId, bool trackChanges);
    EmployeeDto GetEmployeeByCompany(Guid companyId, Guid employeeId, bool trackChanges);
    IEnumerable<EmployeeDto> GetAll(bool trackChanges);
    EmployeeDto GetById(Guid id, bool trackChanges);
    EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateDto employee, bool trackChanges);
}
