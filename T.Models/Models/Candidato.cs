using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T.Models.Models
{
    [Table("Candidato")]
    public class Candidato
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, StringLength(255)]
        public string Nombres { get; set; }
        [Required, StringLength(255)]
        public string Apellidos { get; set; }
        [Required, StringLength(100)]
        public string CorreoElectronico { get; set; }
        [Required, StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required, StringLength(150)]
        public string PuestoAplicado { get; set; }
        [Required]
        public DateTime FechaAplicacion { get; set; }
    }
}
