using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T.Models.Models
{
    [Table("Metricas")]

    public class Metricas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, StringLength(10)]
        public string Http { get; set; } = "";
        [Required]
        public double ConsumoPeticionBytes { get; set; }
        [Required]
        public double TiempoRespuestaMiliSegundos { get; set; }
        [Required]
        public DateTime DateUtc { get; set; }
        [Required, StringLength(20)]
        public string Status { get; set; } = "";
    }
}
