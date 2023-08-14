using Application;
using Application.Presents;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ChildController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChildDto>>> GetAllChildren()
    {
        return Ok(await Mediator.Send(new GetAllChildrenQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ChildDto>>> GetChild(Guid id)
    {
        return Ok(await Mediator.Send(new GetChildQuery(id)));
    }

    [HttpPut]
    public async Task<IActionResult> EditChild(EditChildCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RG(RegisterChildCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveChildren(Guid id)
    {
        await Mediator.Send(new DeleteChildCommand(id));
        return Ok();
    }


}