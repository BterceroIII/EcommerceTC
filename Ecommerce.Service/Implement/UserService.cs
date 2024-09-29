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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Usuario> _modelRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<Usuario> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<SessionDTO> Authorization(LoginDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.Correo == model.Correo && p.Clave == model.Clave);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null) 
                { 
                    return _mapper.Map<SessionDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coicidencias");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserDTO> Create(UserDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Usuario>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdUsuario != 0)
                {
                    return _mapper.Map<UserDTO>(rspModel);
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

        public async Task<bool> Update(UserDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdUsuario == model.IdUsuario);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreCompleto = model.NombreCompleto;
                    fromDbModel.Correo = model.Correo;
                    fromDbModel.Clave = model.Clave;

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
                var consult = _modelRepository.Consult(p => p.IdUsuario == id);
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

        public async Task<List<UserDTO>> List(string rol, string search)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(search.ToLower()));

                List<UserDTO> list = _mapper.Map<List<UserDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdUsuario == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<UserDTO>(fromDbModel);
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


    }
}
