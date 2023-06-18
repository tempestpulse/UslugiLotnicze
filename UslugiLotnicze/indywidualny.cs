namespace UslugiLotnicze;

public class Indywidualny : Klient
{
    public string imie { get; }
    public string nazwisko { get; }





    public Indywidualny(string imie, string nazwisko) : base()
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public override string getImie()
    {
        return this.imie;

    }

    public override string getNazwisko()
    {
        return this.nazwisko;

    }


}