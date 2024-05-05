using Microsoft.EntityFrameworkCore;

namespace OptionsPattern.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
    {
    }
}
