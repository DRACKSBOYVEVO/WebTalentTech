using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class EnfoqueDiferencial
{
    [Key]
    public int EnfoqueDiferencialId { get; set; }
    public string Nombre { get; set; }
}
