﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Contract;
using Ecommerce.DTO;
using Ecommerce.Service.Implement;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet("List/{search:alpha?}")]
        public async Task<IActionResult> ListRol(string search = "NA")
        {
            var response = new ResponseDTO<List<RolDTO>>();

            try
            {
                if (search == "NA") search = "";

                response.EsCorrecto = true;
                response.Resultado = await _rolService.List(search);
            }
            catch (Exception ex)
            {

                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Get/{Id:int?}")]
        public async Task<IActionResult> GetRol(int Id)
        {
            var response = new ResponseDTO<RolDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _rolService.GetRol(Id);
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
