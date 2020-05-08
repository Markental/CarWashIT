using CarWashIT.Models;
using CarWashIT.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole, string>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarNumber> CarNumbers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCar> OrderCars { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderCar>().HasKey(oc => new { oc.OrderId, oc.CarId });

            builder.Entity<OrderCar>()
                .HasOne<Order>(oc => oc.Order)
                .WithMany(o => o.OrderCars)
                .HasForeignKey(oc => oc.OrderId);

            builder.Entity<OrderCar>()
                .HasOne<Car>(oc => oc.Car)
                .WithMany(c => c.OrderCars)
                .HasForeignKey(oc => oc.CarId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
