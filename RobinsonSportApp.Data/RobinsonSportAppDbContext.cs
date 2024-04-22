using Microsoft.EntityFrameworkCore;

namespace RobinsonSportApp.Data;

public class RobinsonSportAppDbContext(DbContextOptions<RobinsonSportAppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
