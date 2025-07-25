using System.Runtime.CompilerServices;
using MegaWish.Application.DTOs;
using MegaWish.Application.Interfaces;
using MegaWish.Domain.Entities;
using MegaWish.Domain.Interfaces;

namespace MegaWish.Application.Services;

public class ZonaService : ZonaServiceInterface
{
    private readonly ZonaRepositoryInterface _repository;

    public ZonaService(ZonaRepositoryInterface repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Zona>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Zona?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

    public async Task AddAsync(ZonaDto dto)
    {
        var zona = new Zona(dto.Nome, dto.LatitudeInicial, dto.LatitudeFinal, dto.LongitudeInicial, dto.LongitudeFinal);
        await _repository.AddAsync(zona);
    }

    public async Task UpdateAsync(Guid id, ZonaDto dto)
    {
        var zona = await _repository.GetByIdAsync(id);

        if (zona == null)
            throw new KeyNotFoundException("Zona não encontrada");

        zona.SetNome(dto.Nome);
        zona.SetCoordenadas(dto.LatitudeInicial, dto.LatitudeFinal, dto.LongitudeInicial, dto.LongitudeFinal);

        await _repository.UpdateAsync(zona);
    }

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}