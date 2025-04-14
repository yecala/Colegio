using DT.Colegio.Modelos;

namespace BM.Colegio.Interfaces
{
    public interface IEstudiante
    {
        Estudiante ObtenerEstudiantePorId(int identificador);

        List<Estudiante> ObtenerEstudiantes();

        bool InsertarEstudiante(Estudiante estudiante);

        bool ActualizarEstudiante(Estudiante estudiante);

        public bool EliminarEstudiante(int id);
    }
}
