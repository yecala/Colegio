using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DA.Colegio.Repositorios
{
    public class MateriaPorGradoRepositorio : GenericRepository<MateriaPorGrado>, IMateriaPorGradoRepositorio
    {
        public MateriaPorGradoRepositorio(AppDbContext context) : base(context) { }
    
        public async Task<bool> ExisteRelacion(int gradoId, int materiaId) {
            return await _context.MateriasPorGrado.AnyAsync(mg => mg.GradoId == gradoId && mg.MateriaId == materiaId);
        }
    }
}
