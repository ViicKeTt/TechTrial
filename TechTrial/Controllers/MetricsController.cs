using Microsoft.AspNetCore.Mvc;

namespace TechTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : ControllerBase
    {
        public MetricsController()
        {
        }

        /// <summary>
        /// Consulta las métricas del consumo del API segmentadas por método HTTP.
        /// </summary>
        /// <param name="date">Fecha por la cual filtrar las métricas (opcional).</param>
        /// <returns>
        /// Información sobre los métodos HTTP usados, cantidad de consumos, tiempos de respuesta 
        /// promedio, mínimo, máximo, TPM (transacciones por minuto) y estado (ERROR u OK).
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
