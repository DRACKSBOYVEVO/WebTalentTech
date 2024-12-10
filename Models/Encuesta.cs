using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models;

public class Encuesta
{
    [Key]
    public int EncuestaId { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MaxLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
    public string Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
    public string Apellidos { get; set; }

    [Required(ErrorMessage = "El tipo de identificación es obligatorio.")]
    public int TipoIdentificacionId { get; set; }
    [ForeignKey("TipoIdentificacionId")]
    public TipoIdentificacion TipoIdentificacion { get; set; }

    [Required(ErrorMessage = "El número de identificación es obligatorio.")]
    [MaxLength(20, ErrorMessage = "El número de identificación no puede exceder los 20 caracteres.")]
    public string NumeroIdentificacion { get; set; }

    [Required(ErrorMessage = "El campo Ocupación es obligatorio.")]
    [MaxLength(50, ErrorMessage = "La ocupación no puede exceder los 50 caracteres.")]
    public string Ocupacion { get; set; }

    [Required(ErrorMessage = "El sexo es obligatorio.")]
    public int SexoId { get; set; }
    [ForeignKey("SexoId")]
    public Sexo Sexo { get; set; }

    [Required(ErrorMessage = "El rango de edad es obligatorio.")]
    public int RangoEdadId { get; set; }
    [ForeignKey("RangoEdadId")]
    public RangoEdad RangoEdad { get; set; }

    public int EnfoqueDiferencialId { get; set; }
    [ForeignKey("EnfoqueDiferencialId")]
    public EnfoqueDiferencial EnfoqueDiferencial { get; set; }

    [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
    [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
    public string CorreoElectronico { get; set; }

    [Phone(ErrorMessage = "Debe ingresar un número de teléfono válido.")]
    [MaxLength(20, ErrorMessage = "El número de teléfono no puede exceder los 20 caracteres.")]
    public string NumeroTelefonico { get; set; }

    public bool FormulacionPorOrganizacion { get; set; }

    public int SectorId { get; set; }
    [ForeignKey("SectorId")]
    public Sector Sector { get; set; }

    public int UbicacionProyectoId { get; set; }
    [ForeignKey("UbicacionProyectoId")]
    public UbicacionProyecto UbicacionProyecto { get; set; }

    public ICollection<Voto> Votos { get; set; }
}