using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.DTOs
{
    public class DocenteDTO
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public string titulo { get; set; }
        public string telefono { get; set; }
        public bool activo { get; set; }
    }
}
