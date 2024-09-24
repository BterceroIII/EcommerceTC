using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;

namespace Ecommerce.Repository.Implement
{
    public class SaleRepository : GenericRepository<Venta>,  ISaleRepository
    {
        private readonly DbecommerceContext _dbContext;

        public SaleRepository(DbecommerceContext dbecommerceContext) : base(dbecommerceContext) 
        {
            _dbContext = dbecommerceContext;
        }

        public async Task<Venta> Register(Venta model)
        {
            Venta saleGenerated = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in model.DetalleVenta)
                    {
                        Producto product_found = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        product_found.Cantidad = product_found.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(product_found);
                    }

                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(model);
                    await _dbContext.SaveChangesAsync();

                    saleGenerated = model;
                    transaction.Commit();
                }
                catch 
                {

                    transaction.Rollback();
                    throw;
                }

                return saleGenerated;
            }
        }
    }
}
