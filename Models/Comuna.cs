using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Comuna
{
    [Key]
    public int ComunaId { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int DepartamentoId { get; set; }
    [ForeignKey("DepartamentoId")]
    public Departamento Departamento { get; set; }
    public ICollection<Barrio> Barrios { get; set; }
}