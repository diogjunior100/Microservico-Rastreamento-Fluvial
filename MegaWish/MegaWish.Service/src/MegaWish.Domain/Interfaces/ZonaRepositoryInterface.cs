using MegaWish.Domain.Entities;

namespace MegaWish.Domain.Interfaces;

public interface ZonaRepositoryInterface
{
    Task<IEnumerable<Zona>> GetAllAsync();
    Task<Zona?> GetByIdAsync(Guid id);
    Task AddAsync(Zona zona);
    Task UpdateAsync(Zona zona);
    Task DeleteAsync(Guid id);
}