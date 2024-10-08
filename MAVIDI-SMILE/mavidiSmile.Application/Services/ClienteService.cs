using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domais.Entities;
using MAVIDI_SMILE.mavidiSmile.Domais.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAVIDI_SMILE.mavidiSmile.Application.Services
{
    public class ClienteService : IClienteApplicationService
    {
        private readonly IClienteRepository _clienteRepository;

        // Construtor para injeção de dependência do repositório
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Método para adicionar um novo cliente (Salvar)
        public Cliente? SalvarDadosCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Nome = clienteDTO.Nome,
            };

            _clienteRepository.AddAsync(cliente).Wait();  // Aguarda o repositório salvar no banco
            return cliente;
        }

        // Método para editar cliente existente
        public Cliente? EditarDadosCliente(int id, ClienteDTO clienteDTO)
        {
            var cliente = _clienteRepository.GetByIdAsync(new Guid(id.ToString())).Result;

            if (cliente == null)
                return null;

            // Atualiza os dados do cliente com base no DTO
            cliente.Nome = clienteDTO.Nome;

            _clienteRepository.UpdateAsync(cliente).Wait();  // Atualiza no banco
            return cliente;
        }

        // Método para deletar cliente por ID
        public Cliente? DeletarDadosCliente(int id)
        {
            var cliente = _clienteRepository.GetByIdAsync(new Guid(id.ToString())).Result;
            if (cliente == null)
                return null;

            _clienteRepository.DeleteAsync(new Guid(id.ToString())).Wait();  // Deleta no banco
            return cliente;
        }

        // Método para obter todos os clientes
        public IEnumerable<Cliente>? ObterTodosClientes()
        {
            var clientes = _clienteRepository.GetAllAsync().Result;  // Obtém todos os clientes
            return clientes;
        }

        // Método para obter cliente por ID
        public Cliente? ObterClientePorId(int id)
        {
            var cliente = _clienteRepository.GetByIdAsync(new Guid(id.ToString())).Result;
            return cliente;
        }

        public Task ObterClientePorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
