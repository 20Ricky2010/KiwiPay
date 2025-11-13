using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;
using KiwiPayAPI.Infrastructure.Data;

namespace KiwiPayAPI.Infrastructure.Repositories;

public class TransaccionRepository : ITransaccionRepository
{
    private readonly AppDbContext _context;
    public TransaccionRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Transaccion transaccion)
    {
        _context.Transacciones.Add(transaccion);
        await _context.SaveChangesAsync();
    }
}
