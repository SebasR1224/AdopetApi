using Domain.Abandonments;
using Domain.Animals;
using Domain.Animals.Entities;
using Domain.FileRecords;
using Domain.Foundations;
using Domain.PasswordRecovery;
using Domain.Primitives;
using Domain.Users;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : DbContext(options)
{
    public DbSet<ReportAbandonment> ReportAbandonments { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Foundation> Foundations { get; set; }
    public DbSet<FileRecord> FileRecords { get; set; }
    public DbSet<PasswordRecoveryToken> PasswordRecoveryTokens { get; set; }
    public DbSet<Specie> Species { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
