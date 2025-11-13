using KiwiPayAPI.Core.Entities;
namespace KiwiPayAPI.Application.Interfaces;

public interface ITransaccionService
{
    Task<Transaccion> RealizarTransaccionAsync(int cuentaId, TipoTransaccion tipo, decimal monto);
}
