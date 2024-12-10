using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class UbicacionProyecto
{
    [Key]
    public int UbicacionProyectoId { get; set; }
    public string Nombre { get; set; }
}
