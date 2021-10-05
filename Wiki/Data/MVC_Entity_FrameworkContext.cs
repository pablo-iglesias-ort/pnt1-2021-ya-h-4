using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Models;

namespace MVC_Entity_Framework.Data
{
    public class MVC_Entity_FrameworkContext : DbContext
    {
        public MVC_Entity_FrameworkContext (DbContextOptions<MVC_Entity_FrameworkContext> opciones) : base(opciones)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(s => s.Email).IsUnique();
        }
        /*
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaEstudiante> MateriasEstudiantes { get; set; }
        ////////*/
        //Se crean los Dbset para migrar tablas y relaciones
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cuerpo> Cuerpos { get; set; }
        public DbSet<Encabezado> Encabezados { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<Referencia> Referencias { get; set; }

    }
}
