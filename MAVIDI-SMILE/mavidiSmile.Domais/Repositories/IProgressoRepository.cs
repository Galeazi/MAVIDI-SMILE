using MAVIDI_SMILE.mavidiSmile.Domais.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Domais.Repositories
{
    public interface IProgressoRepository
    {
        Task<Progresso> GetByClienteIdAsync(Guid clienteId);
        Task AddAsync(Progresso progresso);
    }
}
