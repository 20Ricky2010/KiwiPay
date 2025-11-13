namespace KiwiPayAPI.Core.Entities;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public enum TipoTransaccion { Deposito = 1, Retiro = 2 }

public class Transaccion
{
    public int TransaccionId { get; set; }
    public int CuentaId { get; set; }
    public TipoTransaccion Tipo { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public Cuenta? Cuenta { get; set; }
}
