using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using MAVIDI_SMILE.Domain.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigosController : ControllerBase
    {
        private readonly IAmigosService _amigosService;

        public AmigosController(IAmigosService amigosService)
        {
            _amigosService = amigosService;
        }

        [HttpGet("{usuarioId}")]
        [SwaggerOperation(Summary = "Lista todos os amigos de um usuário", Description = "Este endpoint retorna todos os amigos de um usuário específico.")]
        [Produces(typeof(IEnumerable<Amigo>))]
        public IActionResult GetAmigosPorUsuario(int usuarioId)
        {
            var amigos = _amigosService.ObterAmizadesPorUsuarioId(usuarioId);

            if (amigos != null)
                return Ok(amigos);

            return NotFound("Nenhum amigo encontrado para o usuário especificado.");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicionar amigo", Description = "Este endpoint permite adicionar um novo amigo para o usuário.")]
        [Produces(typeof(Amigo))]
        public IActionResult AdicionarAmigo([FromBody] AmigosDTO amigoDto)
        {
            try
            {
                var amigo = _amigosService.AdicionarAmigo(amigoDto);

                if (amigo != null)
                    return Ok(amigo);

                return BadRequest("Não foi possível adicionar o amigo.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar amizade", Description = "Este endpoint permite atualizar um relacionamento de amizade.")]
        [Produces(typeof(Amigo))]
        public IActionResult AtualizarAmigo(int id, [FromBody] AmigosDTO amigoDto)
        {
            try
            {
                var amigoAtualizado = _amigosService.AtualizarAmizade(id, amigoDto);

                if (amigoAtualizado != null)
                    return Ok(amigoAtualizado);

                return BadRequest("Não foi possível atualizar a amizade.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover amigo", Description = "Este endpoint permite remover um amigo do usuário.")]
        public IActionResult RemoverAmigo(int id)
        {
            _amigosService.RemoverAmigo(id);
            return NoContent();
        }
    }
}
