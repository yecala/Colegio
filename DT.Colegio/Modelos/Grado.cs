using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.Modelos
{
    [Table("tbl_grado")]
    public class Grado
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        public string Nombre { get; set; }

        public ICollection<EstudianteGrado> EstudianteGrados { get; set; }
        public ICollection<MateriaPorGrado> MateriasPorGrado { get; set; }
    }
}
