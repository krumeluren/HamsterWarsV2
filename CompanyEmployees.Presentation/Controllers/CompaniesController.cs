using CompanyEmployees.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject.Company;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var companies = _service.CompanyService.GetAll(trackChanges: false);
        return Ok(companies);
    }

    [HttpGet("{Id:guid}", Name = "GetCompanyById")]
    public IActionResult GetById(Guid id)
    {
        var company = _service.CompanyService.GetById(id, trackChanges: false);
        return Ok(company);
    }

    [HttpGet("collection/({ids})", Name = "GetCompanies")]
    public IActionResult GetCompanies([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var companies = _service.CompanyService.GetByIds(ids, trackChanges: false);
        return Ok(companies);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CompanyCreateDto company)
    {
        if (company == null)
        {
            return BadRequest("Company object is null");
        }
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var companyObj = _service.CompanyService.CreateCompany(company);
        return CreatedAtRoute("GetCompanyById", new {id = companyObj.Id }, companyObj);
    }

    [HttpPost("collection")]
    public IActionResult CreateCompanies([FromBody] IEnumerable<CompanyCreateDto> companies)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var result = _service.CompanyService.CreateCompanies(companies);
        return CreatedAtRoute("GetCompanies", new { result.ids }, result.companies);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        _service.CompanyService.DeleteCompany(id, trackChanges: false);
        return NoContent();
    }
}
