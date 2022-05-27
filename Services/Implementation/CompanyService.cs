using AutoMapper;
using Contracts;
using Domain.Entities.Exceptions;
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
}
