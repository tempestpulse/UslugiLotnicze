namespace UslugiLotnicze;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections;

class SystemRezerwacji
{
    public List<Samolot> samoloty;
    public List<Klient> klienci;
    public List<Trasa> trasy;
    public List<Lot> loty;


    public SystemRezerwacji()
    {
        samoloty = new List<Samolot>();
        klienci = new List<Klient>();
        trasy = new List<Trasa>();
        loty = new List<Lot>();

    }

    public void DodajSamolot(Samolot samolot)
    {
        samoloty.Add(samolot);
    }

    public void UsunSamolot(Samolot samolot)
    {
        samoloty.Remove(samolot);
    }

    public int GetSamolotyIlosc()
    {
        return samoloty.Count;
    }

    public Samolot GetSamolotIndex(int index)
    {
        return samoloty[index];
    }

    public void WyswietlSamoloty()
    {
        for (int i = 0; i < samoloty.Count; i++)
        {
            Samolot samolot = samoloty[i];
            Console.WriteLine(
                $"Samolot {i}: Model - {samolot.Model}, Rozmiar - {samolot.Rozmiar}, Zasieg - {samolot.Zasieg}");
        }
    }

    public void DodajKlienta(Klient klient)
    {
        klienci.Add(klient);
    }

    public void UsunKlienta(Klient klient)
    {
        klienci.Remove(klient);
    }

    public int GetKlientIlosc()
    {
        return klienci.Count;
    }

    public Klient GetKlientByIndex(int index)
    {
        return klienci[index];
    }

    public void WyswietlKlientow()
    {
        for (int i = 0; i < klienci.Count; i++)
        {

            Klient Klient = klienci[i];
            if (klienci[i] is Indywidualny)
            {
                string imie = klienci[i].getImie();
                string nazwisko = klienci[i].getNazwisko();
                Console.WriteLine($"Klient {i}: Imie i nazwisko - {imie} {nazwisko}, Typ - indywidualny");
            }

            else
            {
                string nip = klienci[i].getNip();
                string nazwa = klienci[i].getNazwaFirmy();
                Console.WriteLine($"Klient {i}: Nazwa - {nazwa}, Nip - {nip}, Typ - Posrednik Firmy");
            }


        }
    }

    public void DodajTrase(Trasa trasa)
    {
        trasy.Add(trasa);
    }

    public void UsunTrase(Trasa trasa)
    {
        trasy.Remove(trasa);
    }

    public int GetIloscTras()
    {
        return trasy.Count;
    }

    public Trasa GetIndexTrasy(int index)
    {
        return trasy[index];
    }

    public void WyswietlTrasy()
    {
        for (int i = 0; i < trasy.Count; i++)
        {
            Trasa trasa = trasy[i];
            Console.WriteLine(
                $"Trasa {i}:  Lotnisko Wylotu- {trasa.LotniskoWylotu}, Lotnisko Przylotu - {trasa.LotniskoPrzylotu}, Dystans - {trasa.Dystans}");
        }
    }

    public void GenerujLoty()
    {
        Random random = new Random();
        HashSet<Trasa> przypisaneTrasy = new HashSet<Trasa>();
        int iloscLotowNaSamolot = 0;
        foreach (Samolot samolot in samoloty)
        {
            iloscLotowNaSamolot = 0;
            foreach (Trasa trasa in trasy)
            {

                if (samolot.Zasieg < trasa.Dystans || przypisaneTrasy.Contains(trasa))
                {
                    Console.WriteLine(
                        $"Lot nie został wygenerowany dla samolotu {samolot.Model} oraz trasy z lotniska {trasa.LotniskoWylotu} do {trasa.LotniskoPrzylotu}. Zasięg samolotu jest niewystarczający lub trasa została już przypisana.");
                    continue;
                }
                iloscLotowNaSamolot++;
                if (iloscLotowNaSamolot > 3)
                    break;
                DateTime czasWylotu = DateTime.Now.AddHours(random.Next(48, 168));
                DateTime czasPrzylotu = czasWylotu.AddHours(random.Next(2, 12));

                foreach (Lot powtarzajaceloty in this.loty)
                {
                    while (powtarzajaceloty.CzasPrzylotu.AddHours(24) > czasWylotu && powtarzajaceloty.Samolot == samolot)
                    {

                        czasWylotu = czasWylotu.AddHours(24);
                        czasPrzylotu = czasPrzylotu.AddHours(24);


                    }
                }




                Lot lot = new Lot(samolot, trasa, czasWylotu, czasPrzylotu);

                loty.Add(lot);
                Console.WriteLine(
                    $"Lot wygenerowany dla Samolotu {samolot.Model} oraz Trasy {trasa.LotniskoWylotu} do {trasa.LotniskoPrzylotu}. wylot: {czasWylotu}, przylot: {czasPrzylotu}");

                przypisaneTrasy.Add(trasa);


            }
        }
    }


    private int ObliczCzasPodrozy(Trasa trasa, Samolot samolot)
    {

        return trasa.Dystans / samolot.Zasieg;
    }

    public void ZrobRezerwacje(Klient Klient, int id)
    {


        Klient.przypisanieIdLotu(id);
    }

    public int iloscKlientowNaLot(int idLotu)
    {
        int ilosc = 0;

        foreach (Klient klient in this.klienci)
        {
            if (klient.getIdLotu() == idLotu)
            {
                ilosc++;
            }
        }

        return ilosc;

    }

    public int GetLotyIlosc()
    {
        return loty.Count;
    }

    public Lot GetLotByIndex(int index)
    {
        return loty[index];
    }

    public void WyswietlLoty()
    {
        for (int i = 0; i < loty.Count; i++)
        {
            Lot lot = loty[i];
            Console.WriteLine(
                $"Lot {i}: Samolot - {lot.Samolot.Model}, Trasa - {lot.Trasa.LotniskoWylotu} do {lot.Trasa.LotniskoPrzylotu}, Czas wylotu - {lot.CzasWylotu}, Czas przylotu - {lot.CzasPrzylotu}");
        }
    }

    public void Zapisz()
    {

        string jsonStringLoty = JsonConvert.SerializeObject(this.loty);
        string jsonStringSamoloty = JsonConvert.SerializeObject(this.samoloty);

        string jsonStringTrasy = JsonConvert.SerializeObject(this.trasy);
        File.WriteAllText("Loty" + ".json", jsonStringLoty);
        File.WriteAllText("Samoloty" + ".json", jsonStringSamoloty);

        File.WriteAllText("Trasy" + ".json", jsonStringTrasy);
        string pomoc = "";
        string IMIE = "";
        string NAZWISKO = "";
        string NIP = "";
        string NAZWA = "";
        int id = 0;
        File.WriteAllText("Klienci.txt", "");
        foreach (Klient pomocKlient in klienci)
        {
            if (pomocKlient is PosrednikFirmy)
            {

                NIP = pomocKlient.getNip();
                NAZWA = pomocKlient.getNazwaFirmy();
                id = pomocKlient.getIdLotu();
                pomoc += "Posrednik ";
                pomoc += NIP + " ";
                pomoc += NAZWA + " ";
                pomoc += id.ToString();
            }

            else
            {
                IMIE = pomocKlient.getImie();
                NAZWISKO = pomocKlient.getNazwisko();
                id = pomocKlient.getIdLotu();
                pomoc += "Indywidualny ";
                pomoc += IMIE + " ";
                pomoc += NAZWISKO + " ";
                pomoc += id.ToString();

            }

            using (StreamWriter writer = File.AppendText("Klienci.txt"))
            {
                writer.WriteLine(pomoc);
            }
            pomoc = "";
        }

    }

    public void Odczytaj()
    {
        loty.Clear();

        if (File.Exists("Loty.json"))
        {

            string json = File.ReadAllText("Loty" + ".json");
            this.loty = JsonConvert.DeserializeObject<List<Lot>>(json);
            json = File.ReadAllText("Samoloty" + ".json");
            this.samoloty = JsonConvert.DeserializeObject<List<Samolot>>(json);

            json = File.ReadAllText("Trasy" + ".json");
            this.trasy = JsonConvert.DeserializeObject<List<Trasa>>(json);




            foreach (string linia in File.ReadLines("Klienci.txt"))
            {
                string[] dane = linia.Split(' ');

                if (dane[0] == "Posrednik")
                {
                    Klient posrednik = new PosrednikFirmy(dane[2], dane[1]);
                    posrednik.przypisanieIdLotu(int.Parse(dane[3]));
                    this.klienci.Add(posrednik);
                }

                else
                {
                    Klient iwidualny = new Indywidualny(dane[1], dane[2]);
                    iwidualny.przypisanieIdLotu(int.Parse(dane[3]));
                    this.klienci.Add(iwidualny);
                }

            }


            Console.WriteLine("Dane lotu odczytane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono plików z zapisem.");
        }
    }
}