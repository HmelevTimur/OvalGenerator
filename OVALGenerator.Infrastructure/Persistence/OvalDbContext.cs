using Microsoft.EntityFrameworkCore;
using OVALGenerator.Domain.Entities;

namespace OVALGenerator.Infrastructure.Persistence;

public class OvalDbContext(DbContextOptions<OvalDbContext> options) : DbContext(options)
{
    public DbSet<SecurityBulletinReport> SecurityBulletins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SecurityBulletinReport>(entity =>
        {
            entity.HasIndex(e => e.CveId).IsUnique();
        });
    }
}