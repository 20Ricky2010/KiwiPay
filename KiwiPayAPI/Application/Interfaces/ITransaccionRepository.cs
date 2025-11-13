using KiwiPayAPI.Core.Entities;
namespace KiwiPayAPI.Application.Interfaces;

public interface ITransaccionRepository
{
    Task AddAsync(Transaccion transaccion);
}
