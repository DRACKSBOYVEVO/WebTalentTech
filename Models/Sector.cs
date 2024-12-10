using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class Sector
{
    [Key]
    public int SectorId { get; set; }
    public string Nombre { get; set; }
}
