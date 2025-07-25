namespace MegaWish.Domain.Entities;

public class Zona
{
    public Guid Id { get; private set; }
    public string? Nome { get; private set; }
    public double LatituteInicial { get; private set; }
    public double LatituteFinal { get; private set; }
    public double LongitudeInicial { get; private set; }
    public double LongitudeFinal { get; private set; }

    public Zona () { }
    public Zona(string nome, double latIni, double latFim, double longIni, double longFim)
    {
        Id = Guid.NewGuid();
        SetNome(nome);
        SetCoordenadas(latIni, latFim, longIni, longFim);
    }

    public void SetCoordenadas(double latIni, double latFim, double longIni, double longFim)
    {
        if (latIni >= latFim)
            throw new ArgumentException("Latitute inicial deve ser menor que a final");
        if (longIni >= longFim)
            throw new ArgumentException("Longitute inicial deve ser menor que a final.");

        LatituteFinal = latFim;
        LatituteInicial = latIni;
        LongitudeFinal = longFim;
        LongitudeInicial = longIni;
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da zona eh obrigatorio");

        Nome = nome;
    }
}