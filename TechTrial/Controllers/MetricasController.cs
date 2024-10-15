using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using T.DataAccess.Services.Interfaces.Entites;

namespace TechTrial.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MetricasController : ControllerBase
    {
        private readonly IMetricasService _metricasService;
        public MetricasController(IMetricasService metricasService)
        {
            _metricasService = metricasService;
        }

        /// <summary>
        /// Consulta las métricas del consumo del API segmentadas por método HTTP.
        /// </summary>
        /// <param name="fecha">Fecha por la cual filtrar las métricas (opcional).</param>
        /// <returns>
        /// Información sobre los métodos HTTP usados, cantidad de consumos, tiempos de respuesta 
        /// promedio, mínimo, máximo, TPM (transacciones por minuto) y estado (ERROR u OK).
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string fecha)
        {
            DateTime date;
            bool isValidDate = DateTime.TryParse(fecha, out date);

            if (!isValidDate)
                return BadRequest("La fecha no es válida. Formato esperado: yyyy-dd-MM");

            return Ok(await _metricasService.GetMetricasAsync(date));
        }
    }
}

