using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.Modelos
{
    [Table("tbl_estudianteGrado")]
    public class EstudianteGrado
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("estudianteId")]
        public int? EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]
        public Estudiante Estudiante { get; set; }

        [Column("gradoId")]
        public int? GradoId { get; set; }
        [ForeignKey("GradoId")]
        public Grado Grado { get; set; }

        [Column("anioLectivo")]
        public int? AnioLectivo { get; set; }

        [Column("promovido")]
        public bool? Promovido { get; set; }

        public ICollection<Nota> Notas { get; set; }
    }
}
