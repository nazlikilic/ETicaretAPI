using ETicaretAPİ.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.İnsfrastructure.AppDbContexts
{
    public class AppDbContextProduct : IdentityDbContext<User, Role, string>
    {
        public AppDbContextProduct(DbContextOptions<AppDbContextProduct> options): base(options)
        {  

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
