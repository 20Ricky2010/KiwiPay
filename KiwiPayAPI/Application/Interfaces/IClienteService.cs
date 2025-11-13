using KiwiPayAPI.Core.Entities;
namespace KiwiPayAPI.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ListarAsync();
    Task<Cliente> CrearAsync(Cliente cliente);
    Task<Cliente?> ActualizarAsync(int id, Cliente cliente);
    Task<bool> EliminarAsync(int id);
}
