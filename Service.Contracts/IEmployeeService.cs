using Shared.DataTransferObject;

namespace Service.Contracts;
public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetEmployeesByCompany(Guid companyId, bool trackChanges);
    IEnumerable<EmployeeDto> GetAll(bool trackChanges);
    EmployeeDto GetById(Guid id, bool trackChanges);

}
