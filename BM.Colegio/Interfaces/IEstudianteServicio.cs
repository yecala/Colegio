using DT.Colegio.DTOs;
using DT.Colegio.Modelos;

namespace BM.Colegio.Interfaces
{
    public interface IEstudianteServicio : IGenericService<Estudiante> {
        Task<List<Estudiante>> ObtenerEstudiantesFiltrados(EstudianteDTO filtro);
    }
}
