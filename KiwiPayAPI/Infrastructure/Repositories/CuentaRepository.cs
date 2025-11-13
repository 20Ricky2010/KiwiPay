using Microsoft.EntityFrameworkCore;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;
using KiwiPayAPI.Infrastructure.Data;

namespace KiwiPayAPI.Infrastructure.Repositories;

public class CuentaRepository : ICuentaRepository
{
    private readonly AppDbContext _context;
    public CuentaRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Cuenta cuenta)
    {
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();
    }

    public async Task<Cuenta?> GetByIdAsync(int id)
    {
        return await _context.Cuentas.Include(c => c.Transacciones).FirstOrDefaultAsync(c => c.CuentaId == id);
    }

    public async Task<IEnumerable<Cuenta>> GetByClienteIdAsync(int clienteId)
    {
        return await _context.Cuentas.Where(c => c.ClienteId == clienteId).Include(c => c.Transacciones).ToListAsync();
    }

    public async Task UpdateAsync(Cuenta cuenta)
    {
        _context.Cuentas.Update(cuenta);
        await _context.SaveChangesAsync();
    }
}
