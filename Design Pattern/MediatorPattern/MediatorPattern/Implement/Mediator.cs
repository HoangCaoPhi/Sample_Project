using Microsoft.Extensions.DependencyInjection;

namespace MediatorPattern;
public class Mediator(IServiceProvider serviceProvider) : IMediator
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var requestType = request.GetType();
        var wrapperType = typeof(RequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResponse));             
        var wrapper = (RequestHandlerBase<TResponse>)Activator.CreateInstance(wrapperType);

        return await wrapper.Handle(request, _serviceProvider);
    }
}

public class RequestHandlerWrapper<TRequest, TResponse> : RequestHandlerBase<TResponse> where TRequest : IRequest<TResponse>
{
    public override async Task<TResponse?> Handle(object request, IServiceProvider serviceProvider)
    {
        return await serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>().Handle((TRequest)request);
    }
}

public abstract class RequestHandlerBase<TResponse>
{
    public abstract Task<TResponse?> Handle(object request, IServiceProvider serviceProvider);
}