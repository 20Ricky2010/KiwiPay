// src/app/Presentation/Controllers/TransaccionesController.cs
using Microsoft.AspNetCore.Mvc;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;
using KiwiPayAPI.Presentation.Controllers.Dtos;

[ApiController]
[Route("api/[controller]")]
public class TransaccionesController : ControllerBase
{
    private readonly ITransaccionService _service;

    public TransaccionesController(ITransaccionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Transaccion>> Post([FromBody] RealizarTransaccionDto dto)
    {
        try
        {
            Console.WriteLine($"CuentaId recibido en el backend: {dto.CuentaId}");
            var trans = await _service.RealizarTransaccionAsync(dto.CuentaId, dto.Tipo, dto.Monto);
            return Ok(trans);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.InnerException?.Message ?? ex.Message });
        }
    }
}