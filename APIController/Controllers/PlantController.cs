using Microsoft.AspNetCore.Mvc;
using Core.Contracts.Service.Contracts;
using Core.Shared.DataTransferObject.Battle;

namespace Presentation.APIController.Controllers;
[Route("/matches")]
[ApiController]
public class PlantController : ControllerBase
{
    private readonly IServiceManager _service;

    public PlantController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("We good to go!");
    }
}
