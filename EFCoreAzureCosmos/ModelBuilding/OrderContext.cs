using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreAzureCosmos.ModelBuilding
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Distributor> Distributors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                databaseName: "OrdersDB");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Default Container
            modelBuilder.HasDefaultContainer("Store");

            //Container
            modelBuilder.Entity<Order>()
                .ToContainer("Orders");

            //NoDiscriminator
            modelBuilder.Entity<Order>()
                .HasNoDiscriminator();

            //PartitionKey
            modelBuilder.Entity<Order>()
                .HasPartitionKey(o => o.PartitionKey);

            //ETag
            modelBuilder.Entity<Order>()
                .UseETagConcurrency();

            //PropertyNames
            modelBuilder.Entity<Order>().OwnsOne(
                o => o.ShippingAddress,
                sa =>
                {
                    sa.ToJsonProperty("Address");
                    sa.Property(p => p.Street).ToJsonProperty("ShipsToStreet");
                    sa.Property(p => p.City).ToJsonProperty("ShipsToCity");
                });

            //OwnsMany
            modelBuilder.Entity<Distributor>().OwnsMany(p => p.ShippingCenters);

            //ETagProperty
            modelBuilder.Entity<Distributor>()
                .Property(d => d.ETag)
                .IsETagConcurrency();
        }
    }
}
