using Microsoft.AspNetCore.Mvc;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentasController : ControllerBase
{
    private readonly ICuentaService _service;
    public CuentasController(ICuentaService service) => _service = service;

    [HttpPost("{clienteId}")]
    public async Task<IActionResult> CrearCuenta(int clienteId)
    {
        try
        {
            var cuenta = await _service.CrearCuentaAsync(clienteId);
            return Ok(cuenta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{clienteId}")]
    public async Task<IActionResult> GetCuentas(int clienteId)
    {
        var cuentas = await _service.ListarPorClienteAsync(clienteId);
        return Ok(cuentas);
    }
}
