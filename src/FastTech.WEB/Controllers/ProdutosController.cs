using FastTech.Aplication.Services.ProductHandlers;
using FastTech.Core.MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[Route("api/[controller]")]
public class ProdutosController : MainController
{
    private readonly IMediatrHandler _handler;

    public ProdutosController(IMediatrHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductCommand command)
    {
        return Ok(await _handler.SendCommando(command));
 
    }
}