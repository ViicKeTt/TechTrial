using T.DataAccess.Data;
using T.Models.Models;

namespace TechTrial.Middleware
{
    public class MiddlewareApi
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareApi> _logger;

        public MiddlewareApi(RequestDelegate next, ILogger<MiddlewareApi> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context, TechTrialContext dbContext)
        {
            var routeData = context.GetRouteData();
            if (routeData.Values["controller"]?.ToString() == "Metricas" || routeData.Values["controller"]?.ToString() == "Auth")
            {
                await _next(context);
            }
            else
            {
                // Obtener el tiempo de inicio
                var startTime = DateTime.UtcNow;

                // Obtener el método HTTP y la URL
                var httpMethod = context.Request.Method;
                var url = context.Request.Path;

                // Medir la cantidad de datos consumidos
                long initialContentLength = context.Request.ContentLength ?? 0;

                await _next(context);

                var endTime = DateTime.UtcNow;
                var responseTime = endTime - startTime;

                // Obtener la longitud de respuesta (puedes cambiar el método si no es necesario)
                long responseLength = context.Response.ContentLength ?? 0;

                // Crear el registro del log
                var logEntry = new Metricas
                {
                    Http = httpMethod,
                    TiempoRespuestaMiliSegundos = responseTime.TotalMilliseconds,
                    ConsumoPeticionBytes = initialContentLength + responseLength, // Datos consumidos
                    DateUtc = DateTime.UtcNow
                };

                dbContext.Metricas.Add(logEntry);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
