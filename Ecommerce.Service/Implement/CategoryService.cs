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

namespace Ecommerce.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Categoria> _modelRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Categoria> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO model)
        {
            try
            {
                var exists = await _modelRepository.Consult(p => p.Nombre == model.Nombre).AnyAsync();
                if (exists)
                {
                    throw new TaskCanceledException("Ya existe una categoria con el mismo Nombre");
                }

                var dbModel = _mapper.Map<Categoria>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdCategoria != 0)
                {
                    return _mapper.Map<CategoryDTO>(rspModel);
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

        public async Task<bool> Update(CategoryDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategoria == model.IdCategoria);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
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

        public async Task<List<CategoryDTO>> List(string search)
        {
            try
            {   
                var lowerSearch = search.ToLower();
                var consult = _modelRepository.Consult(p => p.Nombre.ToLower().Contains(lowerSearch)); 


                List<CategoryDTO> list = _mapper.Map<List<CategoryDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategoria == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<CategoryDTO>(fromDbModel);
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategoria == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var answer = await _modelRepository.Delete(fromDbModel);
                    if (!answer)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }

                    return answer;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
