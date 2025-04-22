using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.DTOs
{
    public class MateriaPorGradoDTO
    {
        public int id { get; set; }
        public GradoDTO grado { get; set; }
        public MateriaDTO materia { get; set; }
        public DocenteDTO docente { get; set; }
    }
}
