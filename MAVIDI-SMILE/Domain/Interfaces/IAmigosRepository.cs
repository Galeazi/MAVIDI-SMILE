using System.Collections.Generic;
using MAVIDI_SMILE.Domain.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Interfaces
{
    public interface IAmigosRepository
    {
        Amigo? ObterAmizadePorId(int id);
        IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId);
        Amigo AdicionarAmigo(Amigo amigo);
        Amigo AtualizarAmizade(int id, Amigo amigo);
        void RemoverAmigo(int id);
    }
}