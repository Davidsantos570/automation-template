using Microsoft.EntityFrameworkCore;
using Zitec.Automation.Domain.Entities;

namespace Zitec.Automation.Infra.DataContext;

public class AutomationDbContext : DbContext
{
    public AutomationDbContext(DbContextOptions<AutomationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ItemProcessado> ItensProcessados => Set<ItemProcessado>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutomationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
