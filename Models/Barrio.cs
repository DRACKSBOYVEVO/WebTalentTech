using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Barrio
{
    [Key]
    public int BarrioId { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int ComunaId { get; set; }
    [ForeignKey("ComunaId")]
    public Comuna Comuna { get; set; }
}
