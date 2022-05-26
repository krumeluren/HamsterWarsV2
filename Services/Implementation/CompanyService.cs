using AutoMapper;
using Contracts;
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

    public IEnumerable<CompanyDto> GetAll(bool trackChanges)
    {
        var companies = _repo.Company.GetAll(trackChanges);
        //map to DTO
        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;

    }
}
