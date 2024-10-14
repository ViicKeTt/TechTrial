using System.ComponentModel.DataAnnotations;

namespace T.Models.DTOs
{
    public class CandidatoDto
    {
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [StringLength(255)]
        [Required(ErrorMessage = "Nombres es requerido")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ'`-]+(\s[A-Za-zÀ-ÿ'`-]+)*$", ErrorMessage = "Apellido no debe tener caracteres especiales, ej.(!@#$%) Ect...")]
        public string Nombres { get; set; } = "";
        [DataType(DataType.Text)]
        [StringLength(255)]
        [Required(ErrorMessage = "Apellido es requerido")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ'`-]+(\s[A-Za-zÀ-ÿ'`-]+)*$", ErrorMessage = "Apellido no debe tener caracteres especiales, ej. (!@#$%) Ect...")]
        public string Apellidos { get; set; } = "";
        [StringLength(100)]
        [Required(ErrorMessage = "Correo es requerido")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Correo no es válido")]
        public string CorreoElectronico { get; set; } = "";
        [StringLength(20)]
        [Required(ErrorMessage = "Telefono es requerido")]
        [RegularExpression(@"^(809|829|849)\d{7}$", ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; } = "";
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fecha de nacimineto es requerido")]
        public DateTime FechaNacimiento { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Puesto aplicado es requerido")]
        public string PuestoAplicado { get; set; } = "";
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Fecha de aplicacion es requerido")]
        public DateTime FechaAplicacion { get; set; }
    }
}
