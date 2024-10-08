using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domais.Entities;

public interface IClienteApplicationService
{
    IEnumerable<Cliente>? ObterTodosClientes();
    Cliente? ObterClientePorId(int id);
    Cliente? SalvarDadosCliente(ClienteDTO entity);
    Cliente? EditarDadosCliente(int id, ClienteDTO entity);
    Cliente? DeletarDadosCliente(int id);
}
