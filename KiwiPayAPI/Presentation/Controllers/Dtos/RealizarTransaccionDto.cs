// src/app/Presentation/Controllers/Dtos/RealizarTransaccionDto.cs
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Presentation.Controllers.Dtos
{
    public class RealizarTransaccionDto
    {
        public int CuentaId { get; set; }
        public TipoTransaccion Tipo { get; set; }
        public decimal Monto { get; set; }
    }
}