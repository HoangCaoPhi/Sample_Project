using Microsoft.EntityFrameworkCore;
using OptionsPattern.Contexts;
using OptionsPattern.Options;

namespace OptionsPattern;

public static class ServiceExtensions
{
    public static void AddOptionsService(this IServiceCollection services)
    {
        services.AddOptions<DatabaseOptions>()
                .BindConfiguration(DatabaseOptions.DatabaseMysqlOptions)
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }

    public static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(
                dbContextOptionsBuilder =>
                {
                    var databaseMySqlOptions = configuration
                                                      .GetSection(DatabaseOptions.DatabaseMysqlOptions)
                                                      .Get<DatabaseOptions>();

                    dbContextOptionsBuilder.UseMySQL(databaseMySqlOptions.ConnectionString, mySqlOptionsAction =>
                    {
                        mySqlOptionsAction.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);
                        mySqlOptionsAction.CommandTimeout(databaseMySqlOptions.CommandTimeout);
                    });

                    dbContextOptionsBuilder.EnableDetailedErrors(databaseMySqlOptions.EnableDetailedErrors);
                    dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseMySqlOptions.EnableSensitiveDataLogging);
                }
        );
    }
}
