using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        // Tablas relacionadas con ubicación geográfica
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        // Tablas relacionadas con proyectos sociales y liderazgos
        public DbSet<ProyectoSocial> ProyectoSociales { get; set; }
        public DbSet<LiderSocial> LiderSocials { get; set; }

        // Tablas relacionadas con encuestas y votos
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<Voto> Votos { get; set; }

        // Tablas adicionales relacionadas con enumeraciones
        public DbSet<TipoIdentificacion> TiposIdentificacion { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<RangoEdad> RangosEdad { get; set; }
        public DbSet<EnfoqueDiferencial> EnfoquesDiferenciales { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<UbicacionProyecto> UbicacionesProyecto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones adicionales
            modelBuilder.Entity<Encuesta>()
                .HasMany(e => e.Votos)
                .WithOne(v => v.Encuesta)
                .HasForeignKey(v => v.EncuestaId);

            // Configuración para claves únicas o índices
            modelBuilder.Entity<Ciudad>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            modelBuilder.Entity<Barrio>()
                .HasIndex(b => b.Nombre)
                .IsUnique();

            // Relación entre ProyectoSocial y IdentityUser
            modelBuilder.Entity<ProyectoSocial>()
                .HasOne(p => p.LiderSocial)
                .WithMany()
                .HasForeignKey(p => p.PersonaId);
        }
    }
}
