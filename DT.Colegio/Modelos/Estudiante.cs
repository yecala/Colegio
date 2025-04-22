using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DT.Colegio.Modelos
{
    [Table("tbl_estudiantes")]
    public class Estudiante
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Column("fechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("tipoDocumento")]
        [MaxLength(20)]
        public string TipoDocumento { get; set; }

        [Column("documento")]
        [MaxLength(20)]
        public string Documento { get; set; }

        [Column("direccion")]
        [MaxLength(150)]
        public string Direccion { get; set; }

        [Column("telefono")]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<EstudianteGrado> EstudianteGrados { get; set; }
    }
}
