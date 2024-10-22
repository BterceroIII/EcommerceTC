using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSale([FromBody] SaleDTO model)
        {
            var response = new ResponseDTO<SaleDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _saleService.Register(model);
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
