namespace UslugiLotnicze;

class Lot
{
    public Samolot Samolot { get; }
    public Trasa Trasa { get; }
    public DateTime CzasWylotu { get; }
    public DateTime CzasPrzylotu { get; }

    public Lot(Samolot samolot, Trasa trasa, DateTime czasWylotu, DateTime czasPrzylotu)
    {
        Samolot = samolot;
        Trasa = trasa;
        CzasWylotu = czasWylotu;
        CzasPrzylotu = czasPrzylotu;
    }
}