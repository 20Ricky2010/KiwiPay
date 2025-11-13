using KiwiPayAPI.Core.Entities;
namespace KiwiPayAPI.Application.Interfaces;

public interface ICuentaService
{
    Task<Cuenta> CrearCuentaAsync(int clienteId);
    Task<IEnumerable<Cuenta>> ListarPorClienteAsync(int clienteId);
}
