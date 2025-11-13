using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;
    public ClienteService(IClienteRepository repo) => _repo = repo;

    public async Task<Cliente> CrearAsync(Cliente cliente)
    {
        await _repo.AddAsync(cliente);
        return cliente;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<Cliente>> ListarAsync() => await _repo.GetAllAsync();

    public async Task<Cliente?> ActualizarAsync(int id, Cliente cliente)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return null;
        existing.Nombre = cliente.Nombre;
        existing.Apellido = cliente.Apellido;
        existing.DNI = cliente.DNI;
        existing.FechaRegistro = cliente.FechaRegistro;
        await _repo.UpdateAsync(existing);
        return existing;
    }
}
