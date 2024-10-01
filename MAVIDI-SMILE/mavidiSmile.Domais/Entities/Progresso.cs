namespace MAVIDI_SMILE.mavidiSmile.Domais.Entities
{
    public class Progresso
    {
        public Guid ProgressoId { get; set; }
        public Cliente Clientes { get; set; }
        public ICollection<Premio> Premios { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
