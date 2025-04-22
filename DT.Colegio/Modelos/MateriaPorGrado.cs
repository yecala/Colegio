using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.Modelos
{
    [Table("tbl_materiaPorGrado")]
    public class MateriaPorGrado
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("gradoId")]
        public int? GradoId { get; set; }
        [ForeignKey("GradoId")]
        public Grado Grado { get; set; }

        [Column("materiaId")]
        public int? MateriaId { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; }

        [Column("docenteId")]
        public int? DocenteId { get; set; }
        [ForeignKey("DocenteId")]
        public Docente Docente { get; set; }

        public ICollection<Nota> Notas { get; set; }
    }
}
