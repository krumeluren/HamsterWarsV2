

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers;


[Route("api/companies/{Id}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetEmployeesByCompany(Guid Id)
    {
        var employees = _service.EmployeeService
            .GetEmployeesByCompany(Id, trackChanges: false);
        return Ok(employees);
    }
}

