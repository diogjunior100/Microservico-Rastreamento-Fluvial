using Microsoft.AspNetCore.Mvc;
using MegaWish.Application.DTOs;
using MegaWish.Application.Interfaces;
using MegaWish.Domain.Entities;

namespace MegaWish.Presentation.Controllers;

[ApiController]
[Route("api/zonas")]

public class ZonaController : ControllerBase
{
    private readonly ZonaServiceInterface _service;

    public ZonaController(ZonaServiceInterface service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var zona = await _service.GetByIdAsync(id);
        return zona is null ? NotFound() : Ok(zona);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ZonaDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetAll), null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ZonaDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

}