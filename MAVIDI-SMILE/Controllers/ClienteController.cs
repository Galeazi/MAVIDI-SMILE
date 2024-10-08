using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Domais.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OdontoPrev.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClienteController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpGet]
        //[SwaggerOperation(Summary = "Lista todos os clientes", Description = "Este endpoint retorna uma lista completa de todos os clientes cadastrados.")]
        [Produces(typeof(IEnumerable<Cliente>))]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clienteApplicationService.ObterTodosClientes();

                if (clientes is null)
                    return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[SwaggerOperation(Summary = "Obtém um cliente específico", Description = "Este endpoint retorna os detalhes de um cliente específico com base no ID fornecido.")]
        //[SwaggerResponse(200, "Cliente encontrado com sucesso", typeof(Cliente))]
        //[SwaggerResponse(204, "Cliente não encontrado")]
        //[SwaggerResponse(404, "Falha para obter o cliente")]
        [Produces(typeof(Cliente))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var cliente = _clienteApplicationService.ObterClientePorId(id);

                if (cliente is null)
                    return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
       // [SwaggerOperation(Summary = "Cadastra um novo cliente", Description = "Este endpoint cria um novo cliente com base nas informações fornecidas.")]
       // [SwaggerResponse(200, "Cliente criado com sucesso")]
       // [SwaggerResponse(404, "Falha para inserir o cliente")]
        [Produces(typeof(Cliente))]
        public IActionResult Post([FromBody] ClienteDTO entity)
        {
            try
            {
                var cliente = _clienteApplicationService.SalvarDadosCliente(entity);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[SwaggerOperation(Summary = "Atualiza um clietne existente", Description = "Este endpoint atualiza as informações de um cliente com base no ID fornecido.")]
        //[SwaggerResponse(200, "Cliente atualizado com sucesso")]
        //[SwaggerResponse(404, "Falha para atualizar o cliente")]
        [Produces(typeof(Cliente))]
        public IActionResult Put(int id, [FromBody] ClienteDTO entity)
        {
            try
            {
                var cliente = _clienteApplicationService.EditarDadosCliente(id, entity);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        //[SwaggerOperation(Summary = "Remove um clietne existente", Description = "Este endpoint remove as informações de um cliente com base no ID fornecido.")]
        //[SwaggerResponse(200, "Cliente removido com sucesso")]
        //[SwaggerResponse(404, "Falha para excluir o cliente")]
        [Produces(typeof(Cliente))]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = _clienteApplicationService.DeletarDadosCliente(id);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

