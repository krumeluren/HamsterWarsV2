using Shared.DataTransferObject.Company;

namespace Service.Contracts;
public interface ICompanyService
{
    CompanyDto CreateCompany(CompanyCreateDto company);
    IEnumerable<CompanyDto> GetAll(bool trackChanges);
    CompanyDto GetById(Guid id, bool trackChanges);
    IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

    (IEnumerable<CompanyDto> companies, string ids) CreateCompanies(IEnumerable<CompanyCreateDto> companies);
    void DeleteCompany(Guid companyId, bool trackChanges);
}
