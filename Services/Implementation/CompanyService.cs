using AutoMapper;
using Contracts;
using Domain.Entities.Exceptions;
using Domain.Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace Services.Implementation;
public class CompanyService : ICompanyService
{
    private readonly IRepoManager _repo;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CompanyService(IRepoManager repo, ILoggerManager logger, IMapper mapper)
    {
        _repo = repo;
        _logger = logger;
        _mapper = mapper;
    }
    
    public CompanyDto GetById(Guid id, bool trackChanges)
    {
        var company = _repo.Company.GetById(id, trackChanges);
        
        if(company == null)
        {
            throw new CompanyNotFoundException(id);
        }

        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }

    public IEnumerable<CompanyDto> GetAll(bool trackChanges)
    {
        var companies = _repo.Company.GetAll(trackChanges);
        
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;

    }

    public CompanyDto CreateCompany(CompanyCreateDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repo.Company.CreateCompany(companyEntity);
        _repo.Save();
        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
        return companyToReturn;
    }

    public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids == null)
        {
            throw new IdParametersBadRequestException();
        }
        var companyEntities = _repo.Company.GetByIds(ids, trackChanges);
        if (companyEntities.Count() != ids.Count())
        {
            throw new CollectionByIdsBadRequestException();
        }
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        return companiesDto;
    }

    public (IEnumerable<CompanyDto> companies, string ids) CreateCompanies(IEnumerable<CompanyCreateDto> companies)
    {
        if (companies == null)
        {
            throw new CompanyCollectionBadRequestException();
        }
        var companyEntities = _mapper.Map<IEnumerable<Company>>(companies);
        foreach (var company in companyEntities)
        {
            _repo.Company.CreateCompany(company);
        }
        _repo.Save();
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
        var ids = string.Join(",", companiesDto.Select(x => x.Id));
        return (companiesDto, ids);
    }
}
