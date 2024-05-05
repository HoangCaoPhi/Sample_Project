using Microsoft.AspNetCore.Mvc;
using OptionsPattern.Options;

namespace OptionsPattern.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConfigController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpGet("")]
    public object Get()
    {
        return new
        {
            ConnectionString = _configuration.GetValue<string>("DatabaseMysqlOptions:ConnectionString"),
            EnableRetryOnFailure = _configuration.GetValue<string>("DatabaseMysqlOptions:EnableRetryOnFailure"),
            CommandTimeout = _configuration.GetValue<string>("DatabaseMysqlOptions:CommandTimeout"),
            EnableDetailedErrors = _configuration.GetValue<string>("DatabaseMysqlOptions:EnableDetailedErrors"),
            EnableSensitiveDataLogging = _configuration.GetValue<string>("DatabaseMysqlOptions:EnableSensitiveDataLogging"),
        };
    }

    [HttpGet("options/bind")]
    public object GetConfigByBind()
    {
        DatabaseOptions options = new();
        _configuration.GetSection(DatabaseOptions.DatabaseMysqlOptions)
                .Bind(options);

        return new
        {
            options.ConnectionString,
            options.EnableSensitiveDataLogging,
            options.EnableDetailedErrors,
            options.CommandTimeout,
            options.EnableRetryOnFailure
        };
    }

    [HttpGet("options/get")]
    public object GetByGetType()
    {
        var options = _configuration.GetSection(DatabaseOptions.DatabaseMysqlOptions)
                .Get<DatabaseOptions>();

        if(options is null) ArgumentNullException.ThrowIfNull(options);

        return new
        {
            options.ConnectionString,
            options.EnableSensitiveDataLogging,
            options.EnableDetailedErrors,
            options.CommandTimeout,
            options.EnableRetryOnFailure
        };
    }
}
