using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.DTOs
{
    public class EstudianteDTO
    {
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
        public int Pagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }
}
