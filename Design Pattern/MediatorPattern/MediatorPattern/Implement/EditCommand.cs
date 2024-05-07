
namespace MediatorPattern;
public class EditCommand : IRequest<string>
{
}

public class EditCommandHandler : IRequestHandler<EditCommand, string>
{
    public async Task<string> Handle(EditCommand request)
    {
        await Task.Delay(100);
        return "Update record success!!!";
    }
}
