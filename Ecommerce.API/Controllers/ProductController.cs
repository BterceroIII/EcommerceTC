using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contract;
using Ecommerce.DTO;
using System.Security.AccessControl;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("List/{search:alpha?}")]
        public async Task<IActionResult> ListProduct(string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.EsCorrecto = true;
                response.Resultado = await _productService.List(search);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;

                throw ex;
            }

            return Ok(response);
        }

        [HttpGet("Catalog/{catalog:alpha?}/{search:alpha}")]
        public async Task<IActionResult> Catalog(string catalog, string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if(catalog.ToLower() == "todos")catalog = "";
                if(search == "todos")search = "";

                response.EsCorrecto = true;
                response.Resultado = await _productService.Catalog(catalog,search);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;

                throw ex;
            }

            return Ok(response);
        }
        

        [HttpGet("Get/{Id:int}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.GetProduct(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto= false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje= ex.Message;
            }

            return Ok(response);  
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Update(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;

                throw ex;
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Delete(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;

                throw ex;
            }

            return Ok(response);
        }

    }
}
