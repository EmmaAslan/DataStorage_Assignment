using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProjectManagerEntity> ProjectManagers { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<ServiceEntity> Services { get; set; } = null!;
    public DbSet<StatusTypeEntity> StatusTypes { get; set; } = null!;
    public DbSet<ProjectEntity> Projects { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Lägger till data vid skapande av database
        modelBuilder.Entity<StatusTypeEntity>().HasData(
            new StatusTypeEntity
            {
                Id = 1,
                StatusName = "Not Started",
            },
            new StatusTypeEntity
            {
                Id = 2,
                StatusName = "Ongoing",
            },
            new StatusTypeEntity
            {
                Id = 3,
                StatusName = "Completed! WIHO!",
            }
        );
    }


    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ProjectManagement;Trusted_Connection=True;");
    } */
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectManagerEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Email);
            entity.Property(e => e.Phone);
        });
        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CustomerName);
            entity.Property(e => e.Email);
            entity.Property(e => e.Phone);
        });
        modelBuilder.Entity<ServiceEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ServiceName);
            entity.Property(e => e.Price);
        });
        modelBuilder.Entity<StatusTypeEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StatusName);
        });
        modelBuilder.Entity<ProjectEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectName);
            entity.Property(e => e.ProjectDescription);
            entity.Property(e => e.StartDate);
            entity.Property(e => e.EndDate);
            entity.Property(e => e.ProjectManagerId);
            entity.Property(e => e.CustomerId);
            entity.Property(e => e.ServiceId);
            entity.Property(e => e.StatusId);
        });
    } */
}
