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
            Estudiante respuesta = _estudianteService.ObtenerEstudiantePorId(id);
            return Ok(respuesta);
        }

    }
}
