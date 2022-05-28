using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;

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

    [HttpGet()]
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

    [HttpPost]
    public IActionResult Create([FromBody] CompanyCreateDto company)
    {
        if (company == null)
        {
            return BadRequest("Company object is null");
        }

        var companyObj = _service.CompanyService.CreateCompany(company);

        return CreatedAtRoute("GetCompanyById", new {id = companyObj.Id }, companyObj);
    }
}
