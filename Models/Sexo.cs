using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Sexo
{
    [Key]
    public int SexoId { get; set; }
    public string Nombre { get; set; }
}
