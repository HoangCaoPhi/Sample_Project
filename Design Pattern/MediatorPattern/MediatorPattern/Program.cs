
using MediatorPattern;
using MediatorPattern.Feature;
using Microsoft.Extensions.DependencyInjection;
using static MediatorPattern.Feature.ServiceA;
using static MediatorPattern.Feature.ServiceB;
using static MediatorPattern.Feature.ServiceC;

var services = new ServiceCollection();
services.AddScoped<IMediator, Mediator>();

services.AddScoped<IRequestHandler<ServiceA, string>, ServiceAHandler>();
services.AddScoped<IRequestHandler<ServiceB, string>, ServiceBHandler>();
services.AddScoped<IRequestHandler<ServiceC, string>, ServiceCHandler>();


var serviceProvider = services.BuildServiceProvider();

var mediator = serviceProvider.GetRequiredService<IMediator>();

var messageServiceA = await mediator.Send(new ServiceA());
var messageServiceB = await mediator.Send(new ServiceB());
var messageServiceC = await mediator.Send(new ServiceC());

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine($"Gọi đến Mediator với dữ liệu yêu cầu là ServiceA: {messageServiceA}");
Console.WriteLine($"Gọi đến Mediator với dữ liệu yêu cầu là ServiceB: {messageServiceB}");
Console.WriteLine($"Gọi đến Mediator với dữ liệu yêu cầu là ServiceC: {messageServiceC}");





