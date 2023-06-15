namespace UslugiLotnicze;

class Klient
{
    public string Imie { get; }
    public string Typ { get; }

    public Klient(string imie, string typ)
    {
        Imie = imie;
        Typ = typ;
    }
}