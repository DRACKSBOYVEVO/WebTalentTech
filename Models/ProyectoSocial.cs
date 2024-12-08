using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

/// <summary>
/// Permitir a los líderes sociales subir proyectos con archivos adjuntos. 
/// </summary>
public class ProyectoSocial
{
    [Key]
    public int ProyectoSocialId { get; set; }
    [Required]

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public byte[] Archivo { get; set; }
    [Required]

    public DateTime FechaCreacion { get; set; }
    [Required]

    public string LiderSocialId { get; set; } // Clave foránea hacia IdentityUser
    [ForeignKey("LiderSocialId")]

    public IdentityUser LiderSocial { get; set; }
    [Required]

    public int PersonaId { get; set; }
    [ForeignKey("PersonaId")]

    public LiderSocial Persona { get; set; } // Clave foránea hacia LiderSocial
}
