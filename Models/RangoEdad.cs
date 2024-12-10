using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class RangoEdad
{
    [Key]
    public int RangoEdadId { get; set; }
    public string Descripcion { get; set; }
}
