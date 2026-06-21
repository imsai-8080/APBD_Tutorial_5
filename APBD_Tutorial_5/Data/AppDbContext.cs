using APBD_Tutorial_5.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_Tutorial_5.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PCs> PCs { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PCComponents>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });
        
        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Procesor" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Karta Graficzna" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Pamięć Operacyjna" }
        );
        
        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers { Id = 1, Abbreviation = "INT", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
            new ComponentManufacturers { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
            new ComponentManufacturers { Id = 3, Abbreviation = "KST", FullName = "Kingston Technology", FoundationDate = new DateTime(1987, 10, 17) }
        );
        
        modelBuilder.Entity<Components>().HasData(
            new Components { Code = "INT-I5-124", Name = "Intel Core i5-12400F", ComponentManufacturerId = 1, ComponentTypeId = 1, Description = "6 cores, 12 threads" },
            new Components { Code = "NV-RTX3060", Name = "NVIDIA RTX 3060", ComponentManufacturerId = 2, ComponentTypeId = 2, Description = "12GB GDDR6" },
            new Components { Code = "KST-FURY-8", Name = "Kingston Fury 8GB DDR4", ComponentManufacturerId = 3, ComponentTypeId = 3, Description = "3200MHz CL16" }
        );
        
        modelBuilder.Entity<PCs>().HasData(
            new PCs { Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PCs { Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PCs { Id = 3, Name = "Budget Builder", Weight = 8.0, Warranty = 12, CreatedAt = new DateTime(2026, 6, 20, 10, 0, 0), Stock = 3 }
        );
        
        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PCId = 1, ComponentCode = "INT-I5-124", Amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "NV-RTX3060", Amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "KST-FURY-8", Amount = 2 },
            new PCComponents { PCId = 2, ComponentCode = "INT-I5-124", Amount = 1 },
            new PCComponents { PCId = 2, ComponentCode = "KST-FURY-8", Amount = 1 }
        );
    }
}