using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Context.EfConnection
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<Unit> Units { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
    }
}
