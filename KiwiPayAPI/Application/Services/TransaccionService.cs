using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Application.Services;

public class TransaccionService : ITransaccionService
{
    private readonly ICuentaRepository _cuentaRepo;
    private readonly ITransaccionRepository _transRepo;

    public TransaccionService(ICuentaRepository cuentaRepo, ITransaccionRepository transRepo)
    {
        _cuentaRepo = cuentaRepo;
        _transRepo = transRepo;
    }

    public async Task<Transaccion> RealizarTransaccionAsync(int cuentaId, TipoTransaccion tipo, decimal monto)
    {
        Console.WriteLine($"Buscando cuenta con ID: {cuentaId}");

        var cuenta = await _cuentaRepo.GetByIdAsync(cuentaId);
        if (cuenta == null) throw new Exception("Cuenta no encontrada");

        if (tipo == TipoTransaccion.Retiro)
        {
            if (monto <= 0) throw new Exception("Monto inválido");
            if (cuenta.Saldo < monto) throw new Exception("Saldo insuficiente");
            cuenta.Saldo -= monto;
        }
        else if (tipo == TipoTransaccion.Deposito)
        {
            if (monto <= 0) throw new Exception("Monto inválido");
            cuenta.Saldo += monto;
        }

        var trans = new Transaccion
        {
            CuentaId = cuentaId,
            Tipo = tipo,
            Monto = monto
        };

        await _transRepo.AddAsync(trans);
        await _cuentaRepo.UpdateAsync(cuenta);

        return trans;
    }
}
