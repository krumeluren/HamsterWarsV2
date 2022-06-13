using Microsoft.AspNetCore.Mvc;
using Core.Contracts.Service.Contracts;
using Core.Shared.DataTransferObject.Battle;

namespace Presentation.HamsterWarsAPIController.Controllers;
[Route("/matches")]
[ApiController]
public class BattlesController : ControllerBase
{
    private readonly IServiceManager _service;

    public BattlesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.BattleService.GetAll(trackChanges: false));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_service.BattleService.GetById(id, trackChanges: false));
    }

    [HttpPost]
    public IActionResult Create([FromBody] BattlePostDto battle)
    {
        if (battle == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBattle = _service.BattleService.Create(battle, trackChanges: true);

        return Ok(new { id = createdBattle.Id });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.BattleService.Delete(id, trackChanges: false);
        return Ok();
    }

    [HttpGet("/matchWinners/{id}")]
    public IActionResult GetAllByWinnerHamsterId(int id)
    {
        var battles = _service.BattleService.GetAllByWinnerHamsterId(id, trackChanges: false);
        if(battles.Count() == 0)
        {
            return NotFound();
        }
        return Ok(battles);
    }
}
