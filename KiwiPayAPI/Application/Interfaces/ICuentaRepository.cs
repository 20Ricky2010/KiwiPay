using KiwiPayAPI.Core.Entities;
namespace KiwiPayAPI.Application.Interfaces;

public interface ICuentaRepository
{
    Task<Cuenta?> GetByIdAsync(int id);
    Task<IEnumerable<Cuenta>> GetByClienteIdAsync(int clienteId);
    Task AddAsync(Cuenta cuenta);
    Task UpdateAsync(Cuenta cuenta);
}
