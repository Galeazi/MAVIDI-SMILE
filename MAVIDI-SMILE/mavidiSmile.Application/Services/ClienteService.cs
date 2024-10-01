using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domais.Entities;
using MAVIDI_SMILE.mavidiSmile.Domais.Repositories;

namespace MAVIDI_SMILE.mavidiSmile.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> AdicionarClienteAsync(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Nome = clienteDTO.Nome,
                Nivel = new Nivel { NivelId = clienteDTO.NivelId }
            };

            await _clienteRepository.AddAsync(cliente);

            return clienteDTO;
        }
    }
}
