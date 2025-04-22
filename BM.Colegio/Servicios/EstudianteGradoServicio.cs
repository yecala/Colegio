using BM.Colegio.Interfaces;
using DA.Colegio.Interfaz;
using DT.Colegio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Colegio.Servicios
{
    public class EstudianteGradoServicio : GenericService<EstudianteGrado>, IEstudianteGradoServicio
    {
        public EstudianteGradoServicio(IEstudianteGradoRepositorio repo) : base(repo) { }
    }
}
