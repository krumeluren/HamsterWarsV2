

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject.Employee;

namespace CompanyEmployees.Presentation.Controllers;


[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetEmployeesByCompany(Guid companyId)
    {
        var employees = _service.EmployeeService
            .GetEmployeesByCompany(companyId, trackChanges: false);
        return Ok(employees);
    }
    
    [HttpGet("{employeeId:guid}",Name = "GetEmployeeByCompany")]
    public IActionResult GetEmployeeByCompany(Guid companyId, Guid employeeId)
    {
        var employee = _service.EmployeeService
            .GetEmployeeByCompany(companyId, employeeId, trackChanges: false);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeCreateDto employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee DTO is null");
        }
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var employeeToReturn = _service.EmployeeService
            .CreateEmployeeForCompany(companyId, employee, trackChanges: false);

        return CreatedAtRoute("GetEmployeeByCompany", new {companyId, employeeId = employeeToReturn.Id }, employeeToReturn);
    }

    [HttpDelete("{employeeId:guid}")]
    public IActionResult DeleteEmployeeInCompany(Guid companyId, Guid employeeId)
    {
        _service.EmployeeService.DeleteEmployeeInCompany(companyId, employeeId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{employeeId:guid}")]
    public IActionResult UpdateEmployeeInCompany(Guid companyId, Guid employeeId,
        [FromBody] EmployeeUpdateDto employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee DTO is null");
        }
        _service.EmployeeService.UpdateEmployeeInCompany(companyId, employeeId, employee,
            companyTrackChanges: false, employeeTrackChanges: true);
        return NoContent();
    }

}

