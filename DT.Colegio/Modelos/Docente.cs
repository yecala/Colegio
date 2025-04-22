using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DT.Colegio.Modelos
{
    [Table("tbl_docente")]
    public class Docente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombreCompleto")]
        [MaxLength(100)]
        public string NombreCompleto { get; set; }

        [Column("especialidad")]
        [MaxLength(50)]
        public string Especialidad { get; set; }

        [Column("correo")]
        [MaxLength(100)]
        public string Correo { get; set; }

        [Column("telefono")]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<MateriaPorGrado> MateriasPorGrado { get; set; }
    }
}
