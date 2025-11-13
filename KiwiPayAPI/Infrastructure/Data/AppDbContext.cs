using Microsoft.EntityFrameworkCore;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Cuenta> Cuentas { get; set; } = default!;
    public DbSet<Transaccion> Transacciones { get; set; } = default!;
}
