using MegaWish.Domain.Entities;

namespace MegaWish.Domain.Interfaces;

public interface RastreamentoRepositoryInterface
{
    Task<IEnumerable<Rastreamento>> GetAllAsync(Guid? zonaId = null, DateTime? data = null, string? embarcacaoId = null);

    Task AddAsync(Rastreamento rastreamento);
}