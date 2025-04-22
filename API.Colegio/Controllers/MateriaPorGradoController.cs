using BM.Colegio.Interfaces;
using DT.Colegio.DTOs;
using DT.Colegio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPorGradoController : ControllerBase
    {
        private readonly IMateriaPorGradoServicio _materiaPorGradoService;
        public MateriaPorGradoController(IMateriaPorGradoServicio materiaPorGradoService)
        {
            _materiaPorGradoService = materiaPorGradoService;
        }

        

        [HttpGet("ObtenerMateriaPorGrado")]
        public async Task<IActionResult> ObtenerMateriaPorGrado()
        {
            List <MateriaPorGrado> respuesta = await _materiaPorGradoService.ObtenerMateriaPorGrado();
            return Ok(respuesta);

        }

        [HttpPost("InsertarMateriaPorGrado")]
        public async Task<IActionResult> InsertarMateriaPorGrado([FromBody] MateriaPorGradoDTO materiaPorGradoDTO)
        {
            if (materiaPorGradoDTO != null)
            {
                await _materiaPorGradoService.Insertar(materiaPorGradoDTO);
                return Ok();
            }
            else
            {
                return StatusCode(400, "Solicitud inválida. Verifica los campos obligatorios.");
            }
        }



    }
}
