using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

/// <summary>
/// Representar las ciudades relacionadas con proyectos o líderes sociales.
/// </summary>
public class Ciudad
{
    [Key]
    public int CiudadId { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public int DepartamentoId { get; set; }
    [ForeignKey("DepartamentoId")]

    public Departamento Departamento { get; set; }
}
