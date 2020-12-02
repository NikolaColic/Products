using Microsoft.EntityFrameworkCore;
using Products.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Data.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set;  }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
 
    }
}
