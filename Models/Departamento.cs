using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Departamento
{
    [Key]
    public int DepartamentoId { get; set; }
    [Required]
    public string Nombre { get; set; }
    public ICollection<Comuna> Comunas { get; set; }
}