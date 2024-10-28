using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Service.Implement
{
    public class ProductoService : IProductService
    {
        private readonly IGenericRepository<Producto> _modelRepository;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Producto>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdProducto != 0)
                {
                    return _mapper.Map<ProductDTO>(rspModel);
                }
                else
                {
                    throw new TaskCanceledException("No se puede crear");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(ProductDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdProducto == model.IdProducto);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
                    fromDbModel.Descripcion = model.Descripcion;
                    fromDbModel.IdCategoria = model.IdCategoria;
                    fromDbModel.Precio = model.Precio;
                    fromDbModel.PrecioOferta = model.PrecioOferta;
                    fromDbModel.Cantidad = model.Cantidad;
                    fromDbModel.Imagen = model.Imagen;
                    fromDbModel.Estado = model.Estado;
                    fromDbModel.Codigo = model.Codigo;
                    var answer = await _modelRepository.Edit(fromDbModel);

                    if (!answer)
                    {
                        throw new TaskCanceledException("No se puede editar");
                    }

                    return answer;

                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultados");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdProducto == id && p.Estado == false);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var answer = await _modelRepository.Delete(fromDbModel);

                    if (!answer)
                    {
                        throw new TaskCanceledException("No se puede eliminar");
                    }

                    return answer;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultados");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdProducto == id);
                consult = consult.Include(c => c.IdCategoriaNavigation);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<ProductDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProductDTO>> Catalog(string category, string search)
        {
            try
            {
                // Tuve problemas con la lectura de LINQ en ToLower por lo que decidi guardarlo en una variable

                /*var consult = _modelRepository.Consult(p =>
                string.Concat(p.Nombre.ToLower()).Contains(search.ToLower()) && p.IdCategoriaNavigation.Nombre.ToLower().Contains(category.ToLower())); */

                var lowerSearch = search.ToLower();
                var consult = _modelRepository.Consult(p => p.Nombre.ToLower().Contains(lowerSearch) && p.IdCategoriaNavigation.Nombre.ToLower().Contains(lowerSearch));

                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProductDTO>> List(string search)
        {
            try
            {
                var lowerSearch = search.ToLower();
                var consult = _modelRepository.Consult(p => p.Nombre.ToLower().Contains(lowerSearch));


                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
