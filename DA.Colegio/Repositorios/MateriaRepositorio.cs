using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Colegio.Repositorios
{
    public class MateriaRepositorio : GenericRepository<Materia>, IMateriaRepositorio
    {
        public MateriaRepositorio(AppDbContext context) : base(context) { }
    }

}
