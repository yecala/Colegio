using DA.Colegio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Repositorios
{
    public class TransactionCoordinatorUnitOfWork : ITransactionCoordinatorUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGradoRepositorio GradoRepositorio { get; }
        public IMateriaRepositorio MateriaRepositorio { get; }
        public IDocenteRepositorio DocenteRepositorio { get; }
        public IMateriaPorGradoRepositorio MateriaPorGradoRepositorio { get; }

        public TransactionCoordinatorUnitOfWork(AppDbContext context,
                          IGradoRepositorio gradoRepo,
                          IMateriaRepositorio materiaRepo,
                          IDocenteRepositorio docenteRepo,
                          IMateriaPorGradoRepositorio materiaGradoRepo)
        {
            _context = context;
            GradoRepositorio = gradoRepo;
            MateriaRepositorio = materiaRepo;
            DocenteRepositorio = docenteRepo;
            MateriaPorGradoRepositorio = materiaGradoRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }

}
