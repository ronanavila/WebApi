using MediatR;

namespace FastTech.Aplication.NotificationErrors;

public class NotificationErrorHandler : INotificationHandler<NotificationError>
{
    private readonly List<NotificationError> _errors;
    public NotificationErrorHandler()
    {
        _errors = new List<NotificationError>();
    }

    public async Task Handle(NotificationError notification, CancellationToken cancellationToken)
    {
        _errors.Add(notification);
        await Task.CompletedTask;
    }

    public bool HaveError()
    {
        return _errors.Any();
    }

    public IEnumerable<NotificationError> GetErrors()
    {
        return _errors;
    }

}
