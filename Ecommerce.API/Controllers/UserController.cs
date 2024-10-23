using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("List/{rol:alpha}/{search:alpha?}")]
        public async Task<IActionResult> ListUser(string rol, string search = "NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.EsCorrecto = true;
                response.Resultado = await _userService.List(rol, search);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Get/{Id:int}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.GetUser(Id);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Create(model);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> AuthorizationUser([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Authorization(model);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Update(model);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Delete(Id);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
    }
}
