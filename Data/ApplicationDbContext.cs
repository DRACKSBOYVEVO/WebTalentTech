using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<LiderSocial> LiderSocials { get; set; }
        public DbSet<Voto> Votos { get; set; }
    }
}
