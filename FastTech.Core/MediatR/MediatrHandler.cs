using FastTech.Core.Messages;
using MediatR;

namespace FastTech.Core.MediatR;

public class MediatrHandler : IMediatrHandler
{
    private readonly IMediator _mediatr;

    public MediatrHandler(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    public async Task<bool> SendCommando<T>(T command) where T : BaseCommand
    {
        return await _mediatr.Send(command);
    }
}
