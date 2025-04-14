using BM.Colegio.Interfaces;
using DT.Colegio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante _estudianteService;
        public EstudianteController(IEstudiante estudianteService) 
        {
            _estudianteService = estudianteService;
        }

        [HttpGet("ObtenerEstudiantePorId/{id}")]
        public async Task<IActionResult> ObtenerEstudiantePorId(int id) 
        {
            if (id > 0)
            {
                Estudiante respuesta = _estudianteService.ObtenerEstudiantePorId(id);
                return Ok(respuesta);
            }
            else
            {
                return StatusCode(400, "Solicitud inválida. Verifica los campos obligatorios.");
            }
        }

        [HttpGet("ObtenerEstudiantes")]
        public async Task<IActionResult> ObtenerEstudiantes()
        {
            List<Estudiante> respuesta = _estudianteService.ObtenerEstudiantes();
            return Ok(respuesta);
            
        }

        [HttpPost("InsertarEstudiante")]
        public async Task<IActionResult> InsertarEstudiante([FromBody] Estudiante estudiante)
        {
            if (!string.IsNullOrEmpty(estudiante.nombre) && !string.IsNullOrEmpty(estudiante.documento))
            {
                Boolean resultado =  _estudianteService.InsertarEstudiante(estudiante);

                if (resultado)
                    return StatusCode(201, "El estudiante ha sido creado correctamente");
                else
                    return StatusCode(500, "Ha ocurrido un error creando el estudiante");
            }
            else
            {
                return StatusCode(400, "Solicitud inválida. Verifica los campos obligatorios.");
            }
        }

        [HttpPatch("ActualizarEstudiante")]
        public async Task<IActionResult> ActualizarEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante.id > 0 && (!string.IsNullOrEmpty(estudiante.nombre) || !string.IsNullOrEmpty(estudiante.documento))) 
            { 
                bool resultado =  _estudianteService.ActualizarEstudiante(estudiante);

                if (resultado)
                    return Ok("El estudiante ha sido actualizado correctamente");
                else
                    return StatusCode(500, "Ha ocurrido un error actualizando el estudiante");
            }
            else
            {
                return StatusCode(400, "Solicitud inválida. Verifica los campos obligatorios.");
            }
        }

        [HttpDelete("EliminarEstudiante/{id}")]
        public async Task<IActionResult> EliminarEstudiante(int id)
        {
            if (id > 0)
            {
                bool resultado = _estudianteService.EliminarEstudiante(id);

                if (resultado)
                    return Ok("El estudiante ha sido eliminado correctamente");
                else
                    return StatusCode(500, "Ha ocurrido un error eliminando el estudiante");
            }
            else
            {
                return StatusCode(400, "Solicitud inválida. Verifica los campos obligatorios.");
            }
        }

    }
}
