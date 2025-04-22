using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.Modelos
{
    [Table("tbl_nota")]
    public class Nota
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("estudianteGradoId")]
        public int? EstudianteGradoId { get; set; }
        [ForeignKey("EstudianteGradoId")]
        public EstudianteGrado EstudianteGrado { get; set; }

        [Column("materiaPorGradoId")]
        public int? MateriaPorGradoId { get; set; }
        [ForeignKey("MateriaPorGradoId")]
        public MateriaPorGrado MateriaPorGrado { get; set; }

        [Column("nombreEvaluacion")]
        [MaxLength(100)]
        public string NombreEvaluacion { get; set; }

        [Column("calificacion")]
        public decimal? Calificacion { get; set; }

        [Column("fecha")]
        public DateTime? Fecha { get; set; }
    }
}
