using FastTech.Aplication.Services.ProductHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[Route("api/[controller]")]
public class ProdutosController : MainController
{
    private readonly IMediator _mediator;

    public ProdutosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductRequest command)
    {
        return Ok(await _mediator.Send(command));
 
    }
}