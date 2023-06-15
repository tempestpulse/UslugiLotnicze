namespace UslugiLotnicze;

class Lot
{
    public Samolot Samolot { get; }
    public Trasa Trasa { get; }
    public DateTime DepartureTime { get; }
    public DateTime ArrivalTime { get; }

    public Lot(Samolot samolot, Trasa trasa, DateTime czasWylotu, DateTime czasPrzylotu)
    {
        Samolot = samolot;
        Trasa = trasa;
        DepartureTime = czasWylotu;
        ArrivalTime = czasPrzylotu;
    }
}