using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Models;

public class Estudiantes{
    [Key]
    public int EstudianteId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Campo nombre Obligatorio")]
    public string? Nombre { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten Letras")]
    [Required(ErrorMessage = "Campo apellido Obligatorio")]
    public string? Apellido { get; set; }

    [StringLength(8, ErrorMessage = "La matricula debe de tener 8 numeros")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
    [Required(ErrorMessage = "Campo matricula Obligatorio")]
    public string? Matricula { get; set; }

    [Required(ErrorMessage = "Campo direccion Obligatorio")]
    public string? Direccion { get; set; }

    [StringLength(10, ErrorMessage = "El telefono debe de tener 10 numeros")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten numeros")]
    [Required(ErrorMessage = "Campo telefono Obligatorio")]
    public string? Telefono { get; set; }
}