using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    // esta interfaz sera un generico para todos los modelos
    public interface IGenericRepository<TModel> where TModel : class
    {
        IQueryable<TModel> Consult(Expression<Func<TModel, bool>>? filtro = null);

        Task<TModel> Create(TModel model);

        Task<bool> Edit(TModel model);

        Task<bool> Delete(TModel model);
    }
}
