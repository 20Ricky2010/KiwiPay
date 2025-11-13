namespace KiwiPayAPI.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Cuenta
{
    public int CuentaId { get; set; }
    public int ClienteId { get; set; }
    public string NumeroCuenta { get; set; } = Guid.NewGuid().ToString("N").Substring(0,10);
    [Column(TypeName = "decimal(18,2)")]
    public decimal Saldo { get; set; } = 0m;
    public bool Estado { get; set; } = true;
    public Cliente? Cliente { get; set; }
    public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
}
