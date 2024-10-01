using MAVIDI_SMILE.mavidiSmile.Domais.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Domais.Services
{
    public class ProgressoService
    {
        public void AtualizarProgresso(Progresso progresso)
        {
            progresso.DataAtualizacao = DateTime.UtcNow;
        }
    }
}
