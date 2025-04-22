using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Repositorios
{
    public class DocenteRepositorio : GenericRepository<Docente>, IDocenteRepositorio
    {
    public DocenteRepositorio(AppDbContext context) : base(context) { }
    }
}
