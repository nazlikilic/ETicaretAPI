using ETicaretAPİ.Domain.Entities;
using ETicaretAPİ.İnsfrastructure.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContextProduct contextProduct) : base(contextProduct)
        {

        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
          return await  _contextProduct.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
