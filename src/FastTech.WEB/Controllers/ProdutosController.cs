using FastTech.Aplication.NotificationErrors;
using FastTech.Aplication.Services.ProductHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[Route("api/[controller]")]
public class ProdutosController : MainController
{


    public ProdutosController(INotificationHandler<NotificationError> notificationError, IMediator mediator)
        : base(notificationError, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct([FromBody] RegisterProductRequest request)
    {
        await Mediator.Send(request);

        if (ProcessoInvalido())
            return BadRequest(GetErrors());

        return Ok();

    }
}