using MegaWish.Domain.Enums;

namespace MegaWish.Application.DTOs;

public class RastreamentoDto
{
    public Guid ZonaId { get; set; }
    public DateTime DataHora { get; set; }
    public TipoEvento Evento { get; set; }
    public string EmbarcacaoId { get; set; } = string.Empty;
}
