using Microsoft.EntityFrameworkCore;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;
using KiwiPayAPI.Infrastructure.Data;

namespace KiwiPayAPI.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;
    public ClienteRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _context.Clientes.FindAsync(id);
        if (c == null) return;
        _context.Clientes.Remove(c);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.Include(c => c.Cuentas).ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes.Include(c => c.Cuentas).FirstOrDefaultAsync(c => c.ClienteId == id);
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }
}
