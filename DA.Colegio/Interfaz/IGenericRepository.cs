using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Interfaz
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos();
        Task<T> ObtenerPorId(int id);
        Task Insertar(T entity);
        Task Actualizar(T entity);
        Task Eliminar(int id);
    }
}
