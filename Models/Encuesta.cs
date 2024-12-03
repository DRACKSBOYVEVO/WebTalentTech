using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Encuesta
{
    [Key]
    public int EncuestaId { get; set; }
    [Required]
    public string Descripcion { get; set; }
    public ICollection<Voto> Votos { get; set; }
}