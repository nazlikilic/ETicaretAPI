using ETicaretAPİ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                Id = 1,
                Name = "kot",
                CategoryId = 1,
                Price = 100,
                Stock = 20,
               CreatedDate = new DateTime(1,1,1,1,1,1,1,1,DateTimeKind.Utc)
            },
            new Product
            {
                  Id = 2,
                  Name ="yün kazak",
                  CategoryId = 2,
                  Price = 200,
                  Stock = 20,
                  CreatedDate = new DateTime(1,1,1,1,1,1,1,1,DateTimeKind.Utc)
            },
             new Product
             {
                 Id = 3,
                 Name="penye tişört",
                 CategoryId = 3,
                 Price = 50,
                 Stock = 20,
                 CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc)
             } );
         
        }
    }
}
