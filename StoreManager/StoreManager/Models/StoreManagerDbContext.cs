using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class StoreManagerDbContext: DbContext
    {
        public StoreManagerDbContext(DbContextOptions<StoreManagerDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=HCM-PHONGCT\\SQLEXPRESS;Initial Catalog=StoreManagerDB;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(b =>
            {
                b.HasKey(e => e.userID);
                b.Property(e => e.userID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Products>(b =>
            {
                b.HasKey(e => e.productID);
                b.Property(e => e.productID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Cart>(b =>
            {
                b.HasKey(e => e.cartID);
                b.Property(e => e.cartID).ValueGeneratedOnAdd();
            });

        }
    }
}
