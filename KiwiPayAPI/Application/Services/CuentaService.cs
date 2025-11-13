using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Application.Services;

public class CuentaService : ICuentaService
{
    private readonly ICuentaRepository _cuentaRepo;
    private readonly IClienteRepository _clienteRepo;

    public CuentaService(ICuentaRepository cuentaRepo, IClienteRepository clienteRepo)
    {
        _cuentaRepo = cuentaRepo;
        _clienteRepo = clienteRepo;
    }

    public async Task<Cuenta> CrearCuentaAsync(int clienteId)
    {
        var cliente = await _clienteRepo.GetByIdAsync(clienteId);
        if (cliente == null) throw new Exception("Cliente no encontrado");

        var cuenta = new Cuenta
        {
            ClienteId = clienteId,
            NumeroCuenta = Guid.NewGuid().ToString("N").Substring(0, 10),
            Saldo = 0m,
            Estado = true
        };

        await _cuentaRepo.AddAsync(cuenta);
        return cuenta;
    }

    public async Task<IEnumerable<Cuenta>> ListarPorClienteAsync(int clienteId)
    {
        return await _cuentaRepo.GetByClienteIdAsync(clienteId);
    }
}
