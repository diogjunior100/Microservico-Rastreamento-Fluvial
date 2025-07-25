using Microsoft.EntityFrameworkCore;
using MegaWish.Domain.Entities;
using MegaWish.Domain.Interfaces;
using MegaWish.Infrastructure.Context;

namespace MegaWish.Infrastructure.Repositories;

public class ZonaRepository : ZonaRepositoryInterface
{
    private readonly AppDbContext _context;

    public ZonaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Zona>> GetAllAsync()
        => await _context.Zonas.ToListAsync();

    public async Task<Zona?> GetByIdAsync(Guid id)
        => await _context.Zonas.FindAsync(id);

    public async Task AddAsync(Zona zona)
    {
        _context.Zonas.Add(zona);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Zona zona)
    {
        _context.Zonas.Update(zona);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var zona = await _context.Zonas.FindAsync(id);
        if (zona is null) return;

        _context.Zonas.Remove(zona);
        await _context.SaveChangesAsync();
    }
}
