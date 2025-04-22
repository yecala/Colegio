using BM.Colegio.Interfaces;
using DA.Colegio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Colegio.Servicios
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
            => await _repository.ObtenerTodos();

        public async Task<T> ObtenerPorId(int id)
            => await _repository.ObtenerPorId(id);

        // Hacer el método Insertar virtual para permitir override en servicios específicos
        public virtual async Task Insertar(T entity)
        {
            await _repository.Insertar(entity);
        }

        public async Task Actualizar(T entity)
            => await _repository.Actualizar(entity);

        public async Task Eliminar(int id)
            => await _repository.Eliminar(id);
    }
}
