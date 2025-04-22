using BM.Colegio.Interfaces;
using DT.Colegio.Modelos;
using DA.Colegio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Colegio.Servicios
{
    public class NotaServicio : GenericService<Nota>, INotaServicio
    {
        
        public NotaServicio(INotaRepositorio repo) : base(repo)
        {
     
        }

        public decimal ObtenerPromedioFinal(List<Nota> notas)
        {
            return 0;
        }

        public decimal ObtenerPromedioFinal(int estudianteId)
        {
            throw new NotImplementedException();
        }
    }
}
