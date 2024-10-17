using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;


namespace MAVIDI_SMILE.Application.Services
{
    public class AmigosService(IAmigosRepository repository) : IAmigosService
    {
        private readonly IAmigosRepository _repository = repository;

        public Amigo? ObterAmizadePorId(int id)
        {
            return _repository.ObterAmizadePorId(id);
        }

        public IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId)
        {
            return _repository.ObterAmizadesPorUsuarioId(usuarioId);
        }

        public Amigo AdicionarAmigo(AmigosDTO amigoDto)
        {
            var amigo = new Amigo
            {
                UsuarioId = amigoDto.UsuarioId,
                AmigoId = amigoDto.AmigoId,

                Usuario = new Usuario { Id = amigoDto.UsuarioId },
                AmigoUsuario = new Usuario { Id = amigoDto.AmigoId }
            };
            _repository.AdicionarAmigo(amigo);
            return amigo;
        }


        public Amigo AtualizarAmizade(int id, AmigosDTO amigoDto)
        {
            var amigo = _repository.ObterAmizadePorId(id);
            if (amigo != null)
            {
                amigo.UsuarioId = amigoDto.UsuarioId;
                amigo.AmigoId = amigoDto.AmigoId;
                _repository.AtualizarAmizade(id, amigo);
            }
            return amigo;
        }

        public void RemoverAmigo(int id)
        {
            _repository.RemoverAmigo(id);
        }
    }
}