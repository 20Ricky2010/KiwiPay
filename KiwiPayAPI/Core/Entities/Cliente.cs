namespace KiwiPayAPI.Core.Entities;

using System;
using System.Collections.Generic;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    public ICollection<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
}
