namespace UslugiLotnicze;

public class Klient
{

    public int id_lotu = -1;


    public void przypisanieIdLotu(int id)
    {
        this.id_lotu = id;
    }

    public int getIdLotu()
    {
        return this.id_lotu;
    }


    public virtual string getNazwaFirmy()
    {
        return "";

    }

    public virtual string getNip()
    {
        return "";

    }
    public virtual string getNazwisko()
    {
        return "";

    }

    public virtual string getImie()
    {
        return "";

    }


}