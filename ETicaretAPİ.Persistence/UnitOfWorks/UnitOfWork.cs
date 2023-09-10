using ETicaretAPİ.Apllication.UnitOfWorks;
using ETicaretAPİ.İnsfrastructure.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPİ.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContextProduct _contextProduct;

        public UnitOfWork(AppDbContextProduct contextProduct)
        {
            _contextProduct= contextProduct;
        }

        public void Commit()
        {
           _contextProduct.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _contextProduct.SaveChangesAsync();
        }
    }
}
