using FastTech.Aplication.NotificationErrors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected readonly NotificationErrorHandler NotificationError;
    public MainController(INotificationHandler<NotificationError> notificationError, IMediator mediator)
    {
        NotificationError = (NotificationErrorHandler)notificationError;
        Mediator = mediator;
    }

    protected bool ProcessoInvalido()
    {
        return NotificationError.HaveError();
    }

    protected IEnumerable<NotificationError> GetErrors()
    {
        return NotificationError.GetErrors();
    }
}
