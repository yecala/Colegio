using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Interfaz
{
    public interface ITransactionCoordinatorUnitOfWork : IDisposable
    {
        IGradoRepositorio GradoRepositorio { get; }
        IMateriaRepositorio MateriaRepositorio { get; }
        IDocenteRepositorio DocenteRepositorio { get; }
        IMateriaPorGradoRepositorio MateriaPorGradoRepositorio { get; }

        Task<int> SaveChangesAsync();
    }

}
