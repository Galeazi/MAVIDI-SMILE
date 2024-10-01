using MAVIDI_SMILE.mavidiSmile.Domais.Entities;
using MAVIDI_SMILE.mavidiSmile.Domais.Repositories;
using MAVIDI_SMILE.mavidiSmile.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly OdontoPrevContext _context;

        public ClienteRepository(OdontoPrevContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
