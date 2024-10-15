using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T.Models.Models
{
    [Table("Metrics")]

    public class Metrics
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string HttpCode { get; set; }
        [Required]
        public double Consumo { get; set; }
        [Required]
        public double TiempoRespuesta { get; set; }
        //[Required]
        //public double Transacciones { get; set; }

    }
}
