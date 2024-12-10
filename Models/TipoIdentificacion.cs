using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class TipoIdentificacion
{
    [Key]
    public int TipoIdentificacionId { get; set; }
    public string Nombre { get; set; }
}
