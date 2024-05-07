
using MediatorPattern;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<IMediator, Mediator>();

services.AddScoped<IRequestHandler<AddCommand, string>, AddCommandHanlder>();
services.AddScoped<IRequestHandler<EditCommand, string>, EditCommandHandler>();


var serviceProvider = services.BuildServiceProvider();

var mediator = serviceProvider.GetRequiredService<IMediator>();

var messageAdd = await mediator.Send(new AddCommand());
var messageUpdate = await mediator.Send(new EditCommand());

Console.WriteLine(messageAdd);   
Console.WriteLine(messageUpdate);



