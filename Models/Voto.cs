using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Voto
{
    [Key]
    public int VotoId { get; set; }
    [Required]
    public int EncuestaId { get; set; }
    [ForeignKey("EncuestaId")]
    public Encuesta Encuesta { get; set; }
    [Required]
    public int LiderSocialId { get; set; }
    [ForeignKey("LiderSocialId")]
    public LiderSocial LiderSocial { get; set; }
    [Required]
    public DateTime FechaVoto { get; set; }
}