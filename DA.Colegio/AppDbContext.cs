using Microsoft.EntityFrameworkCore;
using DT.Colegio.Modelos; // o el namespace donde tengas tus entidades como Estudiante, Grado, etc.

namespace DA.Colegio
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<EstudianteGrado> EstudiantesGrado { get; set; }
        public DbSet<MateriaPorGrado> MateriasPorGrado { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names, keys, and relationships via Fluent API if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
