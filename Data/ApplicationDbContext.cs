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

        DbSet<Barrio> Barrios { get; set; }
        DbSet<Comuna> Comunas { get; set; }
        DbSet<Departamento> Departamentos { get; set; }
        DbSet<Encuesta> Encuestas { get; set; }
        DbSet<LiderSocial> LiderSocials { get; set; }
        DbSet<Voto> Votos { get; set; }
    }
}
