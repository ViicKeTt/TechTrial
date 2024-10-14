using T.DataAccess.Services.Interfaces.Entites;

namespace T.DataAccess.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync();

        #region Servicios de entidad
        ICandidatoService Candidato { get; }
        #endregion

    }
}
