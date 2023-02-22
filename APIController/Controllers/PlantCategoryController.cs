using Microsoft.AspNetCore.Mvc;
using Core.Contracts.Service.Contracts;
using Core.Shared.DataTransferObject.Battle;

namespace Presentation.HamsterWarsAPIController.Controllers;
[Route("/plantCategories")]
[ApiController]
public class PlantCategoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public PlantCategoryController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Category controller online all systems nominal");
    }
}
