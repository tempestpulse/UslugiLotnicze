namespace UslugiLotnicze;

class Trasa
{
    public string LotniskoWylotu { get; }
    public string LotniskoPrzylotu { get; }
    public int Dystans { get; }

    public Trasa(string lotniskoWylotu, string lotniskoPrzylotu, int dystans)
    {
        LotniskoWylotu = lotniskoWylotu;
        LotniskoPrzylotu = lotniskoPrzylotu;
        Dystans = dystans;
    }
}