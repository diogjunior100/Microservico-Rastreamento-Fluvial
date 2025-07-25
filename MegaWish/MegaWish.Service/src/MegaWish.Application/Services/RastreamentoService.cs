using MegaWish.Application.DTOs;
using MegaWish.Application.Interfaces;
using MegaWish.Domain.Entities;
using MegaWish.Domain.Interfaces;

namespace MegaWish.Application.Services;

public class RastreamentoService : RastreamentoServiceInterface
{
    private readonly RastreamentoRepositoryInterface _repository;

    public RastreamentoService(RastreamentoRepositoryInterface repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Rastreamento>> GetAllAsync(Guid? zonaId = null, DateTime? data = null, string? embarcacaoId = null)
    {
        return await _repository.GetAllAsync(zonaId, data, embarcacaoId);
    }

    public async Task AddAsync(RastreamentoDto dto)
    {
        var rastreamento = new Rastreamento(dto.ZonaId, dto.DataHora, dto.Evento, dto.EmbarcacaoId);
        await _repository.AddAsync(rastreamento);
    }
}
