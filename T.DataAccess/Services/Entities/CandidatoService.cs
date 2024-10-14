using T.DataAccess.Data;
using T.DataAccess.Services.Interfaces.Entites;
using T.Models.Models;

namespace T.DataAccess.Services.Entities
{
    public class CandidatoService : Repository<Candidato>, ICandidatoService
    {
        TechTrialContext _db;
        public CandidatoService(TechTrialContext db)
            : base(db)
        {
            _db = db;
        }
    }
}
