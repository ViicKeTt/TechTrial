using T.Models.Models;

namespace T.DataAccess.Services.Interfaces.Entites
{
    public interface ICandidatoService : IRepository<Candidato>
    {
        void Update(Candidato category);
    }
}
