namespace MediatorPattern;
public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}
