using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using Microsoft.EntityFrameworkCore;
using DT.Colegio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Repositorios
{
    public class EstudianteRepositorio : GenericRepository<Estudiante>, IEstudianteRepositorio
    {
        public EstudianteRepositorio(AppDbContext context) : base(context) { }

        public async Task<List<Estudiante>> ObtenerConFiltros(EstudianteDTO filtro)
        {
            var query = _context.Estudiantes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                query = query.Where(e => e.Nombre.Contains(filtro.Nombre));

            if (filtro.Activo.HasValue)
                query = query.Where(e => e.Activo == filtro.Activo.Value);

            return await query
                .OrderBy(e => e.Nombre)
                .Skip((filtro.Pagina - 1) * filtro.TamanoPagina)
                .Take(filtro.TamanoPagina)
                .ToListAsync();
        }

    }
}
