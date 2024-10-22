using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("List/{search:alpha?}")]
        public async Task<IActionResult> ListCategory(string search = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.EsCorrecto = true;
                response.Resultado = await _categoryService.List(search);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Get/{Id:int?}")]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoryService.GetCategory(Id);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoryService.Create(model);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoryService.Update(model);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete ("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoryService.Delete(Id);
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
