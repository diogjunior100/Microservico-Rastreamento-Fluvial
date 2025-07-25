using MegaWish.Domain.Entities;
using MegaWish.Application.DTOs;

namespace MegaWish.Application.Interfaces;

public interface RastreamentoServiceInterface
{
    Task<IEnumerable<Rastreamento>> GetAllAsync(Guid? zonaId = null, DateTime? data = null, string? embarcacaoId = null);
    Task AddAsync(RastreamentoDto dto);
}
