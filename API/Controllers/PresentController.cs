using Application;
using Application.Presents;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PresentController : BaseApiController
{
    [HttpGet("all/{id}")]
    public async Task<ActionResult<IEnumerable<PresentDto>>> GetAllChildsPresents(Guid id)
    {
        return Ok(await Mediator.Send(new GetAllChildsPresentsQuery(id)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PresentDto>>> GetPresent(Guid id)
    {
        return Ok(await Mediator.Send(new GetPresentQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> AssignNewPresent(AssignPresentCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditPresent(EditPresentCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePresent(Guid id)
    {
        await Mediator.Send(new RemovePresentCommand(id));
        return Ok();
    }
}
