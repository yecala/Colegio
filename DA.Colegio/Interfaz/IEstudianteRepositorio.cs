using DT.Colegio.DTOs;
using DT.Colegio.Modelos;

namespace DA.Colegio.Interfaz
{
    public interface IEstudianteRepositorio : IGenericRepository<Estudiante>
    {
        Task<List<Estudiante>> ObtenerConFiltros(EstudianteDTO filtro);
    }
}
