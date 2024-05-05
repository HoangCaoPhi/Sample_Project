using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Sample.Application;
using Sample.Application.Common;
using Sample.Application.Models;
using Sample.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<CustomExceptionFilter>();
builder.Services.AddControllers(op =>
{
    op.Filters.Add<CustomExceptionFilter>();
});

// Add Newston Json Config
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateFormatHandling = ConvertConfig.JSONDateFormatHandling;
        options.SerializerSettings.DateTimeZoneHandling = ConvertConfig.JSONDateTimeZoneHandling;
        options.SerializerSettings.DateFormatString = ConvertConfig.JSONDateFormatString;
        options.SerializerSettings.NullValueHandling = ConvertConfig.JSONNullValueHandling;
        options.SerializerSettings.ReferenceLoopHandling = ConvertConfig.JSONReferenceLoopHandling;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var services = builder.Services;
// Inject Layer

// Inject DbContext
PersistenceFactory.InjectDbContext(services, builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
 
PersistenceFactory.InjectServices(services);

ApplicationFactory.InjectMediatR(services);
ApplicationFactory.InjectServices(services);

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


// Applying Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    //DbInitializer.Initialize(db);
}

StartupParamater.CurrentServiceProvider = app.Services;


app.Run();


