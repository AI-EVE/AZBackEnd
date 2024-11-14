using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<ClientImage> ClientImages { get; set; } = null!;
    public DbSet<ClientPhone> ClientPhones { get; set; } = null!;
    public DbSet<ClientSocial> ClientSocials { get; set; } = null!;
    public DbSet<SocialType> SocialTypes { get; set; } = null!;
    public DbSet<CarMaker> CarMakers { get; set; } = null!;
    public DbSet<CarModel> CarModels { get; set; } = null!;
    public DbSet<CarGeneration> CarGenerations { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<CarImage> CarImages { get; set; } = null!;
    public DbSet<CarSection> CarSections { get; set; } = null!;
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
    public DbSet<ProductMaker> ProductMakers { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductImages> ProductImages { get; set; } = null!;
    public DbSet<ProductCarGeneration> ProductCarGenerations { get; set; } = null!;
    public DbSet<Shop> Shops { get; set; } = null!;
    public DbSet<ShopImage> ShopImages { get; set; } = null!;
    public DbSet<ShopPhone> ShopPhones { get; set; } = null!;
    public DbSet<ShopSocial> ShopSocials { get; set; } = null!;
    public DbSet<ShopBillImage> ShopBillImages { get; set; } = null!;
    public DbSet<ProductBought> ProductsBought { get; set; } = null!;
    public DbSet<ProductOrder> ProductOrders { get; set; } = null!;
    public DbSet<ServiceStatus> ServiceStatuses { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<ServiceProductOrder> ServiceProductOrders { get; set; } = null!;
    public DbSet<ServiceFee> ServiceFees { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<ClientImage>(entity =>
        {
            entity
            .HasOne(ci => ci.Client)
            .WithMany(c => c.ClientImages)
            .HasForeignKey(ci => ci.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ClientPhone>(entity =>
        {
            entity
            .HasOne(cp => cp.Client)
            .WithMany(c => c.ClientPhones)
            .HasForeignKey(cp => cp.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasIndex(cp => cp.PhoneNumber)
            .IsUnique();
        });

        modelBuilder.Entity<ClientSocial>(entity =>
        {
            entity
            .HasOne(cs => cs.Client)
            .WithMany(c => c.ClientSocials)
            .HasForeignKey(cs => cs.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasOne(cs => cs.SocialType)
            .WithMany(st => st.ClientSocials)
            .HasForeignKey(cs => cs.SocialTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        });


        modelBuilder.Entity<SocialType>(entity =>
        {
            entity.
            HasIndex(st => st.Type)
            .IsUnique();
        });

        modelBuilder.Entity<CarMaker>(entity =>
        {
            entity
            .HasIndex(cm => cm.Name)
            .IsUnique();
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity
            .HasOne(cm => cm.CarMaker)
            .WithMany(cm => cm.CarModels)
            .HasForeignKey(cm => cm.CarMakerId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasIndex(cm => new { cm.Name, cm.CarMakerId })
            .IsUnique();
        });

        modelBuilder.Entity<CarGeneration>(entity =>
        {
            entity
            .HasOne(cg => cg.CarModel)
            .WithMany(cm => cm.CarGenerations)
            .HasForeignKey(c => c.CarModelId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasIndex(c => new { c.Name, c.CarModelId })
            .IsUnique();
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity
            .HasOne(c => c.CarGeneration)
            .WithMany(cg => cg.Cars)
            .HasForeignKey(c => c.CarGenerationId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(c => c.Client)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasIndex(c => c.Plate)
            .IsUnique();
        });

        modelBuilder.Entity<CarImage>(entity =>
        {
            entity
            .HasOne(ci => ci.Car)
            .WithMany(c => c.CarImages)
            .HasForeignKey(ci => ci.CarId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CarSection>(entity =>
        {
            entity
            .HasIndex(cs => cs.Name)
            .IsUnique();
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity
            .HasIndex(pt => pt.Name)
            .IsUnique();
        });

        modelBuilder.Entity<ProductMaker>(entity =>
        {
            entity
            .HasIndex(pm => pm.Name)
            .IsUnique();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity
            .HasIndex(c => c.Name)
            .IsUnique();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
            .HasOne(p => p.CarSection)
            .WithMany(cs => cs.Products)
            .HasForeignKey(p => p.CarSectionId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(p => p.ProductType)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.ProductTypeId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(p => p.ProductMaker)
            .WithMany(pm => pm.Products)
            .HasForeignKey(p => p.ProductMakerId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(p => p.CountryOfOrigin)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CountryOfOriginId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ProductImages>(entity =>
        {
            entity
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductImages)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProductCarGeneration>(entity =>
        {
            entity.HasKey(pc => new { pc.ProductId, pc.CarGenerationId });

            entity.HasOne(pc => pc.Product)
                  .WithMany(p => p.ProductCarGenerations)
                  .HasForeignKey(pc => pc.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(pc => pc.CarGeneration)
                  .WithMany(cg => cg.ProductCarGenerations)
                  .HasForeignKey(pc => pc.CarGenerationId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(pc => new { pc.ProductId, pc.CarGenerationId })
                  .IsUnique();
        });

        modelBuilder.Entity<ShopSocial>(entity =>
        {
            entity
            .HasOne(ss => ss.Shop)
            .WithMany(s => s.ShopSocials)
            .HasForeignKey(ss => ss.ShopId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasOne(ss => ss.SocialType)
            .WithMany(st => st.ShopSocials)
            .HasForeignKey(ss => ss.SocialTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ShopImage>(entity =>
        {
            entity
            .HasOne(si => si.Shop)
            .WithMany(s => s.ShopImages)
            .HasForeignKey(si => si.ShopId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ShopPhone>(entity =>
        {
            entity
            .HasOne(sp => sp.Shop)
            .WithMany(s => s.ShopPhones)
            .HasForeignKey(sp => sp.ShopId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasIndex(sp => sp.PhoneNumber)
            .IsUnique();
        });

        modelBuilder.Entity<ShopBillImage>(entity =>
        {
            entity
            .HasOne(sb => sb.Shop)
            .WithMany(s => s.ShopProducts)
            .HasForeignKey(sb => sb.ShopId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProductBought>(entity =>
        {
            entity
            .HasOne(pb => pb.Product)
            .WithMany(p => p.ProductsBought)
            .HasForeignKey(pb => pb.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(pb => pb.Shop)
            .WithMany(s => s.ProductsBought)
            .HasForeignKey(pb => pb.ShopId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity
            .HasOne(po => po.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(po => po.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(po => po.Client)
            .WithMany(c => c.ProductOrders)
            .HasForeignKey(po => po.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ServiceStatus>(entity =>
        {
            entity
            .HasIndex(ss => ss.Status)
            .IsUnique();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity
            .HasOne(s => s.ServiceStatus)
            .WithMany(ss => ss.Services)
            .HasForeignKey(s => s.ServiceStatusId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(s => s.Car)
            .WithMany(c => c.Services)
            .HasForeignKey(s => s.CarId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ServiceProductOrder>(entity =>
        {
            entity
            .HasOne(spo => spo.Service)
            .WithMany(s => s.ServiceProductOrders)
            .HasForeignKey(spo => spo.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasOne(spo => spo.Product)
            .WithMany(p => p.ServiceProductOrders)
            .HasForeignKey(spo => spo.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ServiceFee>(entity =>
        {
            entity
            .HasOne(sf => sf.Service)
            .WithMany(s => s.ServiceFees)
            .HasForeignKey(sf => sf.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

            entity
            .HasOne(sf => sf.CarSection)
            .WithMany(cs => cs.ServiceFees)
            .HasForeignKey(sf => sf.CarSectionId)
            .OnDelete(DeleteBehavior.Restrict);
        });

    }
}
