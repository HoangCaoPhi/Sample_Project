using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Options;

namespace OptionsPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptionsController(IOptions<DatabaseOptions> databaseOptions,
    IOptionsSnapshot<DatabaseOptions> databaseOptionsSnapshot,
    IOptionsMonitor<DatabaseOptions> databaseOptionsMonitor) : Controller
{
    private readonly IOptions<DatabaseOptions> _databaseOptions = databaseOptions;
    private readonly IOptionsSnapshot<DatabaseOptions> _databaseOptionsSnapshot = databaseOptionsSnapshot;
    private readonly IOptionsMonitor<DatabaseOptions> _databaseOptionsMonitor = databaseOptionsMonitor;

    [HttpGet("")]
    public object Get()
    {
        return new
        {
            _databaseOptions.Value.ConnectionString,
            _databaseOptions.Value.EnableRetryOnFailure,
            _databaseOptions.Value.CommandTimeout,
            _databaseOptions.Value.EnableDetailedErrors,
            _databaseOptions.Value.EnableSensitiveDataLogging
        };
    }

    [HttpGet("all")]
    public object GetChange()
    {
        return new
        {
            Options = GetWithIOptions(),
            OptionsSnapshot = GetWithIOptionsSnapshot(),
            OptionsMonitor = GetWithIOptionsMonitor()
        };
    }

    [HttpGet("all-delay")]
    public async Task<object> GetChangeDelay()
    {
        // delay 10s
        var oldData = new
        {
            OptionsMonitorValue = _databaseOptionsMonitor.CurrentValue.ChangeMe,
            OptionsSnapshotValue = _databaseOptionsSnapshot.Value.ChangeMe
        };
 
        await Task.Delay(10000);
 
        var newData = new
        {
            OptionsMonitorValue = _databaseOptionsMonitor.CurrentValue.ChangeMe,
            OptionsSnapshotValue = _databaseOptionsSnapshot.Value.ChangeMe
        };
        return new {
            oldData,
            newData
        };
    }
 
    private object GetWithIOptions()
    {
        return new
        {
            _databaseOptions.Value.ConnectionString,
            _databaseOptions.Value.EnableRetryOnFailure,
            _databaseOptions.Value.CommandTimeout,
            _databaseOptions.Value.EnableDetailedErrors,
            _databaseOptions.Value.EnableSensitiveDataLogging,
            _databaseOptions.Value.ChangeMe
        };
    }

    private object GetWithIOptionsSnapshot()
    {        
        return new
        {
            _databaseOptionsSnapshot.Value.ConnectionString,
            _databaseOptionsSnapshot.Value.EnableRetryOnFailure,
            _databaseOptionsSnapshot.Value.CommandTimeout,
            _databaseOptionsSnapshot.Value.EnableDetailedErrors,
            _databaseOptionsSnapshot.Value.EnableSensitiveDataLogging,
            _databaseOptionsSnapshot.Value.ChangeMe
        };
    }

    private object GetWithIOptionsMonitor()
    {
        
        return new
        {
            _databaseOptionsMonitor.CurrentValue.ConnectionString,
            _databaseOptionsMonitor.CurrentValue.EnableRetryOnFailure,
            _databaseOptionsMonitor.CurrentValue.CommandTimeout,
            _databaseOptionsMonitor.CurrentValue.EnableDetailedErrors,
            _databaseOptionsMonitor.CurrentValue.EnableSensitiveDataLogging,
            _databaseOptionsMonitor.CurrentValue.ChangeMe
        };
    }
}
