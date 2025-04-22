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
    public class GradoServicio : GenericService<Grado>, IGradoServicio
    {
        public GradoServicio(IGradoRepositorio repo) : base(repo) { }
    }
}
