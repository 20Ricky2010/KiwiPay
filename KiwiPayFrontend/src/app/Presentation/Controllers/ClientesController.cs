using Microsoft.AspNetCore.Mvc;
using KiwiPayAPI.Application.Interfaces;
using KiwiPayAPI.Core.Entities;

namespace KiwiPayAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;
    public ClientesController(IClienteService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ListarAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Cliente cliente)
    {
        var created = await _service.CrearAsync(cliente);
        return CreatedAtAction(nameof(Get), new { id = created.ClienteId }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cliente cliente)
    {
        var updated = await _service.ActualizarAsync(id, cliente);
        if (updated == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.EliminarAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
