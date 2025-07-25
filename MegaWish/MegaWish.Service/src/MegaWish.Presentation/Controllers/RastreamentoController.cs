using Microsoft.AspNetCore.Mvc;
using MegaWish.Application.DTOs;
using MegaWish.Application.Interfaces;

namespace MegaWish.Presentation.Controllers;

[ApiController]
[Route("api/rastreamento")]
public class RastreamentoController : ControllerBase
{
    private readonly RastreamentoServiceInterface _service;

    public RastreamentoController(RastreamentoServiceInterface service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] Guid? zonaId,
        [FromQuery] DateTime? data,
        [FromQuery] string? embarcacaoId)
    {
        var result = await _service.GetAllAsync(zonaId, data, embarcacaoId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RastreamentoDto dto)
    {
        await _service.AddAsync(dto);
        return Ok();
    }
}
