using MegaWish.Domain.Enums;

namespace MegaWish.Domain.Entities;

public class Rastreamento
{
    public Guid Id { get; private set; }
    public Guid ZonaId { get; private set; }
    public DateTime DataHora { get; private set; }
    public TipoEvento Evento { get; private set; }
    public string EmbarcacaoId { get; private set; }

    public Rastreamento(Guid zonaId, DateTime dataHora, TipoEvento evento, string embarcacaoId)
    {
        Id = Guid.NewGuid();
        ZonaId = zonaId;
        DataHora = dataHora;
        Evento = evento;
        EmbarcacaoId = embarcacaoId ?? throw new ArgumentNullException(nameof(embarcacaoId));
    }
}
