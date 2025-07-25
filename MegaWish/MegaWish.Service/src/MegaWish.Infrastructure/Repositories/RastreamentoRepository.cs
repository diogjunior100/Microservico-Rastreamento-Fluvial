using Microsoft.EntityFrameworkCore;
using MegaWish.Domain.Entities;
using MegaWish.Domain.Interfaces;
using MegaWish.Infrastructure.Context;

namespace MegaWish.Infrastructure.Repositories;

public class RastreamentoRepository : RastreamentoRepositoryInterface
{
    private readonly AppDbContext _context;

    public RastreamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rastreamento>> GetAllAsync(Guid? zonaId = null, DateTime? data = null, string? embarcacaoId = null)
    {
        var query = _context.Rastreamentos.AsQueryable();

        if (zonaId.HasValue)
            query = query.Where(r => r.ZonaId == zonaId);

        if (data.HasValue)
            query = query.Where(r => r.DataHora.Date == data.Value.Date);

        if (!string.IsNullOrWhiteSpace(embarcacaoId))
            query = query.Where(r => r.EmbarcacaoId == embarcacaoId);

        return await query.ToListAsync();
    }

    public async Task AddAsync(Rastreamento rastreamento)
    {
        _context.Rastreamentos.Add(rastreamento);
        await _context.SaveChangesAsync();
    }
}
