using System;
using System.Collections.Generic;
using System.Text;
using DoAnWebBanGiay.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderShoes>().HasKey(u => new
            {
                u.ShoesID,
                u.ProviderID
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Brands> Brands { set; get; }
        public DbSet<Shoes> Shoes { set; get; }
        public DbSet<Providers> Providers { set; get; }
        public DbSet<ShoeTypes> ShoeTypes { set; get; }
        public DbSet<ProviderShoes> ProviderShoes { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }
    }
}
