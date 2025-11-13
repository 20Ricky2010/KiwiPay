using Microsoft.AspNetCore.Mvc;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaccionesController : ControllerBase
{
    private readonly ITransaccionService _service;
    public TransaccionesController(ITransaccionService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TransaccionDto dto)
    {
        try
        {
            var t = await _service.RealizarTransaccionAsync(dto.CuentaId, dto.Tipo, dto.Monto);
            return Ok(t);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

public record TransaccionDto(int CuentaId, TipoTransaccion Tipo, decimal Monto);
