using Domain.Abandonments;
using Domain.Animals;
using Domain.FileRecords;
using Domain.Foundations;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ReportAbandonment> ReportAbandonments { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Foundation> Foundations { get; set; }
    public DbSet<FileRecord> FileRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
