using BM.Colegio.Interfaces;
using BM.Colegio.Servicios;
using DT.Colegio.Modelos;
using DT.Colegio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteServicio _service;
        public EstudianteController(IEstudianteServicio service) => _service = service;

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetAll() => Ok(await _service.ObtenerTodos());

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var item = await _service.ObtenerPorId(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Estudiante entity)
        {
            await _service.Insertar(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Estudiante entity)
        {
            if (id != entity.Id) return BadRequest();
            await _service.Actualizar(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudiantes([FromQuery] EstudianteDTO filtro)
        {
            var estudiantes = await _service.ObtenerEstudiantesFiltrados(filtro);
            return Ok(estudiantes);
        }
    }
}
