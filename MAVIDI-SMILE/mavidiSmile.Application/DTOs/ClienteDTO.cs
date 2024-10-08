using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.mavidiSmile.Application.DTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = $"Campo {nameof(Nome)} é obrigatório")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Campo deve ter no mínimo 5 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(NivelId)} é obrigatório")]
        public Guid NivelId { get; set; }
    }
}
