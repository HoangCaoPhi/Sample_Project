
namespace MediatorPattern;
public class AddCommand : IRequest<string>
{

}

public class AddCommandHanlder : IRequestHandler<AddCommand, string>
{
    public async Task<string> Handle(AddCommand request)
    {
        await Task.Delay(100);
        return "Add record success!!!";
    }
}