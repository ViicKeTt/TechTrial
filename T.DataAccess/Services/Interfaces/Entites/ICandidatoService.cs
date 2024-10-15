using T.Models.DTOs;

namespace T.DataAccess.Services.Interfaces.Entites
{
    public interface IMetricasService
    {
        Task<IEnumerable<MetricasDto>> GetMetricasAsync(DateTime fecha);
        Task<MetricasRequest> AddMetricasAsync(MetricasRequest metricas);
    }
}
