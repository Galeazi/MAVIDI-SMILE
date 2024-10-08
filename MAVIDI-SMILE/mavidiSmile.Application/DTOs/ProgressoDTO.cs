using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.mavidiSmile.Application.DTOs
{
    public class ProgressoDTO
    {
        [Required(ErrorMessage = $"Campo {nameof(ClienteId)} é obrigatório")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(DataAtualizacao)} é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
        public DateTime DataAtualizacao { get; set; }
    }
}
