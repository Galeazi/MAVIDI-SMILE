namespace MAVIDI_SMILE.mavidiSmile.Domais.Entities
{
    public class Nivel
    {
        public Guid NivelId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
