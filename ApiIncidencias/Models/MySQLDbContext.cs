using Microsoft.EntityFrameworkCore;
using ApiIncidencias.Models;


namespace ApiIncidencias.Models
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estado> Estado { get; set; }

        public DbSet<Tipo> Tipo { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<Equipo> Equipo { get; set; }

        public DbSet<Sede> Sede { get; set; }

        public DbSet<Localidad> Localidad { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<Tecnico> Tecnico { get; set; }

        public DbSet<EstadoUsuario> EstadoUsuario { get; set; }

        public DbSet<TicketEnCurso> TicketEnCurso { get; set; }

        public DbSet<EstadoConexion> EstadoConexion { get; set; }

        
    }  
}
