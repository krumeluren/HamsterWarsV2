using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
        try
        {
            var companies = _service.CompanyService.GetAll(trackChanges: false);
            return Ok(companies);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
