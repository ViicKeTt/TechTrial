using AutoMapper;
using Microsoft.EntityFrameworkCore;
using T.DataAccess.Data;
using T.Models.DTOs;
using T.Models.Models;

namespace T.DataAccess.Services.Interfaces.Entites
{
    public class MetricasService : IMetricasService
    {
        private readonly TechTrialContext _context;
        private readonly IMapper _mapper;
        public MetricasService(TechTrialContext techTrialContext, IMapper mapper)
        {
            _context = techTrialContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MetricasDto>> GetMetricasAsync(DateTime fecha)
        {
            var metricas = await _context.Metricas
                .Where(w => w.DateUtc.Date == fecha.Date.Date)
                .GroupBy(gb => gb.Http)
                .Select(s => new MetricasDto()
                {
                    HttpCode = s.Key,
                    ConsumoPeticion = s.Select(cp => cp.ConsumoPeticionBytes).Sum().ToString() + " bytes",
                    TiempoRespuestaMinimo = s.Select(tr => tr.TiempoRespuestaMiliSegundos).Min(),
                    TiempoRespuestaPromedio = s.Select(tr => tr.TiempoRespuestaMiliSegundos).Average(),
                    TiempoRespuestaMaximo = s.Select(tr => tr.TiempoRespuestaMiliSegundos).Max(),
                    TPM = s.Select(s => s.Status).Count() / 60, // transacciones por minuto,
                    Resultado = s.Select(s => s.Status).FirstOrDefault()
                }).ToListAsync();

            return metricas;
        }

        public async Task<MetricasRequest> AddMetricasAsync(MetricasRequest metricas)
        {
            await _context.Metricas.AddAsync(_mapper.Map<Metricas>(metricas));
            await _context.SaveChangesAsync();

            return metricas;
        }
    }
}
