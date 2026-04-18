namespace PrimerWebAPI.Modelos
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
    }

}
