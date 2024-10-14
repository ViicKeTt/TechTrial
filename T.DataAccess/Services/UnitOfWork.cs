using T.DataAccess.Data;
using T.DataAccess.Services.Entities;
using T.DataAccess.Services.Interfaces;
using T.DataAccess.Services.Interfaces.Entites;

namespace T.DataAccess.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechTrialContext _context;
        public UnitOfWork(TechTrialContext trialContext)
        {
            _context = trialContext;
            Candidato = new CandidatoService(_context);
        }
        public ICandidatoService Candidato { get; private set; }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        // Dispose nos ayuda a liberar recursos no administrados
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
