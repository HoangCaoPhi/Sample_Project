using System.ComponentModel.DataAnnotations;

namespace OptionsPattern.Options;

public class DatabaseOptions
{
    public const string DatabaseMysqlOptions = "DatabaseMysqlOptions";

    [Required(AllowEmptyStrings = false)]
    public string ConnectionString { get; set; }

    public int EnableRetryOnFailure { get; set; }

    [Range(10, 50)]
    public int CommandTimeout { get; set; }

    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
    public int ChangeMe { get; set; }
}

