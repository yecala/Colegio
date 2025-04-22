using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Repositorios
{
    public class NotaRepositorio : GenericRepository<Nota>, INotaRepositorio
    {
        public NotaRepositorio(AppDbContext context) : base(context) { }

        public List<Nota> ObtenerNotasPorEstudiante(int estudianteId)
        {
            throw new NotImplementedException();
        }
    }
}
