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
        //Tillfällig data för att visa att det fungerar
        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity
            {
                Id = 1,
                CustomerName = "Kalle",
                Email = "kalle@domain.com",
                Phone = "070-1234567"
            },
            new CustomerEntity
            {
                Id = 2,
                CustomerName = "KodKompisarna AB",
                Email = "kodkompisarna@domain.com",
                Phone = "070-2345678"
            },
            new CustomerEntity
            {
                Id = 3,
                CustomerName = "Anna Svensson",
                Email = "anna@domain.com",
                Phone = "070-3456789"
            }
        );

        //Tillfällig data för att visa att det fungerar
        modelBuilder.Entity<ProjectEntity>().HasData(
            new ProjectEntity
            {
                Id = 1,
                Title = "KodKompisarna",
                Description = "KodKompisarna ska bygga en hemsida",
                StartDate = new DateOnly(2022, 01, 01),
                EndDate = new DateOnly(2022, 12, 31),
                TotalPrice = 10000,
                ProjectManagerId = 1,
                CustomerId = 2,
                ServiceId = 1,
                StatusTypeId = 1
            },
            new ProjectEntity
            {
                Id = 2,
                Title = "Webbdesign för Anna",
                Description = "Skapa en modern portfolio för Anna Svensson",
                StartDate = new DateOnly(2023, 03, 01),
                EndDate = new DateOnly(2023, 08, 31),
                TotalPrice = 5000,
                ProjectManagerId = 1,
                CustomerId = 3,
                ServiceId = 1,
                StatusTypeId = 2
            }

        );

        //Tillfällig data för att visa att det fungerar
        modelBuilder.Entity<ProjectManagerEntity>().HasData(
            new ProjectManagerEntity
            {
                Id = 1,
                FirstName = "Kalle",
                LastName = "Karlsson",
                Email = "kalle.karlsson@domain.com",
                Phone = "071-1234567"
            }

        );

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


       
        
        
        
        //Tillfällig data för att visa att det fungerar
        modelBuilder.Entity<ServiceEntity>().HasData(
            new ServiceEntity
            {
                Id = 1,
                ServiceName = "Webbdesign",
                Price = 10000
            },
            new ServiceEntity
            {
                Id = 2,
                ServiceName = "SEO-optimering",
                Price = 5000
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
