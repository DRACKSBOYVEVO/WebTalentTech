using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class LiderSocial
{
    [Key]
    public int LiderSocialId { get; set; }
    [Required]

    public string Nombre { get; set; }
    [Required]

    public int BarrioId { get; set; }
    [ForeignKey("BarrioId")]
    public Barrio Barrio { get; set; }

    public int CiudadId { get; set; }
    [ForeignKey("CiudadId")]
    public Ciudad Ciudad { get; set; }
}