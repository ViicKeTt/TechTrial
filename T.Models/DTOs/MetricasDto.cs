using System.ComponentModel.DataAnnotations;

namespace T.Models.DTOs
{
    public class MetricasRequest
    {
        public int ID { get; set; }
        [AllowedValues("get", "post", "put", "delete", ErrorMessage = "Valores permitido: get, post, put, delete")] // valores permitidos para el campo HttpCode, para este caso
        [Required, StringLength(10)]
        public string Http { get; set; } = "";
        [Required]
        public double ConsumoPeticion { get; set; }
        [Required]
        public double TiempoRespuestaMiliSegundos { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }
    public class MetricasDto
    {
        public string HttpCode { get; set; } = "";
        public string ConsumoPeticion { get; set; }
        public double TiempoRespuestaMinimo { get; set; }
        public double TiempoRespuestaPromedio { get; set; }
        public double TiempoRespuestaMaximo { get; set; }
        public DateOnly Date { get; set; }
        public int TPM { get; set; }
        public string Resultado { get; set; }
    }
}
