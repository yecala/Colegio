using BM.Colegio.Interfaces;
using DA.Colegio;
using DT.Colegio.Constantes;
using DT.Colegio.Modelos;

namespace BM.Colegio.Servicios
{
    public class EstudianteServicio:IEstudiante
    {
        public Estudiante ObtenerEstudiantePorId(int identificador)
        {
            try
            {
                Estudiante respuesta = new Estudiante();
                respuesta = new ExecSP<Estudiante>().ExecFirst(Procedimientos.ObtenerEstudiantePorId, new { id = identificador });
                return respuesta;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                throw; // mejor que "throw e" porque preserva el stack original
            }
        }

    }
}
