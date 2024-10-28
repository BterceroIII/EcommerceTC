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
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _modelRepository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> List(string search)
        {
            try
            {
                var lowerSearch = search.ToLower();
                var consult = _modelRepository.Consult(p => p.NombreRol.ToLower().Contains(lowerSearch));


                List<RolDTO> list = _mapper.Map<List<RolDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<RolDTO> Create(RolDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Rol>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdRol != 0)
                {
                    return _mapper.Map<RolDTO>(rspModel);
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

        public async Task<bool> Update(RolDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdRol == model.IdRol);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreRol = model.NombreRol;
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

        public async Task<RolDTO> GetRol(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdRol == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<RolDTO>(fromDbModel);
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
                var consult = _modelRepository.Consult(p => p.IdRol == id);
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
