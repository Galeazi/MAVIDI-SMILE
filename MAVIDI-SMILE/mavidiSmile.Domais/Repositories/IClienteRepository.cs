﻿using MAVIDI_SMILE.mavidiSmile.Domais.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Domais.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(Guid id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Cliente cliente);
    }
}
