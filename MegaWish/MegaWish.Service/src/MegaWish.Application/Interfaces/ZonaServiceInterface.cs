using MegaWish.Domain.Entities;
using MegaWish.Application.DTOs;

namespace MegaWish.Application.Interfaces;

public interface ZonaServiceInterface
{
    Task<IEnumerable<Zona>> GetAllAsync();
    Task<Zona?> GetByIdAsync(Guid id);
    Task AddAsync(ZonaDto dto);
    Task UpdateAsync(Guid id, ZonaDto dto);
    Task DeleteAsync(Guid id);
}