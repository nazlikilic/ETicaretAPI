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
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category { Id = 1 , Name="Pantolonlar", CreatedDate= new DateTime(1,1,1,1,1,1,1,1,DateTimeKind.Utc)},
            new Category { Id = 2 , Name = "Kazaklar", CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc) },
            new Category { Id = 3, Name = "Tişörtler", CreatedDate = new DateTime(1, 1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc) }
            );

        }
    }
}
