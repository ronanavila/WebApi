using FastTech.Core.Messages;

namespace FastTech.Core.MediatR;

public interface IMediatrHandler
{
    Task<bool> SendCommando<T>(T command) where T : BaseCommand;
}