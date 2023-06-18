namespace UslugiLotnicze;

public class PosrednikFirmy : Klient
{
    public string nazwa { get; }
    public string nip { get; }



    public PosrednikFirmy(string nazwa, string nip) : base()
    {
        this.nazwa = nazwa;
        this.nip = nip;
    }

    public override string getNip()
    {
        return this.nip;

    }

    public override string getNazwaFirmy()
    {
        return this.nazwa;

    }


}