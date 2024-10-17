
using System.Collections.Generic;
using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;

namespace MAVIDI_SMILE.mavidiSmile.Application.Interfaces
{
    public interface IAmigosService
    {
        Amigo? ObterAmizadePorId(int id);
        IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId);
        Amigo AdicionarAmigo(AmigosDTO amigoDto);
        Amigo AtualizarAmizade(int id, AmigosDTO amigoDto);
        void RemoverAmigo(int id);
    }
}