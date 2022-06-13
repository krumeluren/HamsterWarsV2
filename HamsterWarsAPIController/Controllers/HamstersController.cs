using Microsoft.AspNetCore.Mvc;
using Core.Contracts.Service.Contracts;
using Core.Shared.DataTransferObject.Hamster;

namespace Presentation.HamsterWarsAPIController.Controllers;
[Route("/hamsters")]
[ApiController]
public class HamstersController : ControllerBase
{
    private readonly IServiceManager _service;

    public HamstersController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var hamsters = _service.HamsterService.GetAll(trackChanges: false);
        foreach (var hamster in hamsters)
        {
            hamster.ImgData = _service.ImageHandler.GetFile(hamster.ImgName);
        }
        return Ok(hamsters);
    }

    [HttpGet("random")]
    public IActionResult GetRandom()
    {
        var hamster = _service.HamsterService.GetRandom(trackChanges: false);
        hamster.ImgData = _service.ImageHandler.GetFile(hamster.ImgName);
        return Ok(hamster);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var hamster = _service.HamsterService.GetById(id, trackChanges: false);
        if (hamster == null)
        {
            return NotFound();
        }
        hamster.ImgData = _service.ImageHandler.GetFile(hamster.ImgName);
        return Ok(hamster);
    }

    [HttpPost]
    public IActionResult Create([FromBody] HamsterPostDto hamster)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        
        //random name for image file
        hamster.ImgName = Guid.NewGuid().ToString() + hamster.ImgName;
        
        _service.ImageHandler.Upload(hamster.ImgData, hamster.ImgName);
        var createdHamster = _service.HamsterService.Create(hamster, trackChanges: false);
        
        return Ok(new { id = createdHamster.Id });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] HamsterPutDto hamster)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        _service.HamsterService.Update(id, hamster, trackChanges: true);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.HamsterService.Delete(id, trackChanges: true);
        return Ok();
    }

    [HttpGet("/winners")]
    public IActionResult GetWinners()
    {
        var hamsters = _service.HamsterService.TopWinners(5, trackChanges: false);
        foreach (var hamster in hamsters)
        {
            hamster.ImgData = _service.ImageHandler.GetFile(hamster.ImgName);
        }
        return Ok(hamsters);
    }

    [HttpGet("/losers")]
    public IActionResult GetLosers()
    {
        var hamsters =  _service.HamsterService.TopLosers(5, trackChanges: false);
        foreach (var hamster in hamsters)
        {
            hamster.ImgData = _service.ImageHandler.GetFile(hamster.ImgName);
        }
        return Ok(hamsters);
    }
}
