using BM.Colegio.Interfaces;
using DA.Colegio;
using DT.Colegio.Constantes;
using DT.Colegio.Modelos;
using System.Collections;

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

        public List<Estudiante> ObtenerEstudiantes()
        {
            try
            {
                List<Estudiante> respuesta = new ExecSP<Estudiante>().Exec(Procedimientos.ObtenerEstudiantes);
                return respuesta;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                throw; // mejor que "throw e" porque preserva el stack original
            }
        }

        public bool InsertarEstudiante(Estudiante estudiante)
        {
            try
            {
                new ExecSP<Estudiante>().ExecAsync(Procedimientos.InsertarEstudiante, estudiante);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                return false;
                throw; 
                
            }
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                new ExecSP<Estudiante>().ExecAsync(Procedimientos.ActualizarEstudiante, estudiante);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                return false;
                throw;

            }
        }

        public bool EliminarEstudiante(int id)
        {
            try
            {
                new ExecSP<Estudiante>().ExecAsync(Procedimientos.EliminarEstudiante, new { id = id });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                return false;
                throw;

            }
        }

    }
}
