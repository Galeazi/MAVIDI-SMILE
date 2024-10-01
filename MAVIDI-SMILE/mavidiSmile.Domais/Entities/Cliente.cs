namespace MAVIDI_SMILE.mavidiSmile.Domais.Entities
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public Nivel Nivel { get; set; }
        public Progresso Progresso { get; set; }
        public ICollection<Amigos> amigos { get; set; }
    }
}
