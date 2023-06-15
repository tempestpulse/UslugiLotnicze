namespace UslugiLotnicze;
using System.Globalization;

class SystemRezerwacji
{
    private List<Samolot> samoloty;
    private List<Klient> klienci;
    private List<Trasa> trasy;
    private List<Lot> loty;

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

    public int GetKlientCount()
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
            Console.WriteLine($"Klient {i}: Imie - {Klient.Imie}, Typ - {Klient.Typ}");
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
                $"Trasa {i}: Departure Airport - {trasa.LotniskoWylotu}, Arrival Airport - {trasa.LotniskoPrzylotu}, Dystans - {trasa.Dystans}");
        }
    }

    public void GenerujLoty()
    {
        foreach (Trasa trasa in trasy)
        {
            foreach (Samolot samolot in samoloty)
            {
                int czasPodrozy = ObliczCzasPodrozy(trasa, samolot);
                if (samolot.Zasieg < trasa.Dystans)
                {
                    Console.WriteLine(
                        $"Lot not generated for Samolot {samolot.Model} and Trasa {trasa.LotniskoWylotu} to {trasa.LotniskoPrzylotu}. Samolot zasieg is insufficient.");
                    continue;
                }

                DateTime czasWylotu = DateTime.Now;
                DateTime czasPrzylotu = czasWylotu.AddHours(czasPodrozy);

                Lot lot = new Lot(samolot, trasa, czasWylotu, czasPrzylotu);

                loty.Add(lot);
                Console.WriteLine(
                    $"Lot wygenerowany dla Samolotu {samolot.Model} oraz Trasy {trasa.LotniskoWylotu} do {trasa.LotniskoPrzylotu}.");
            }
        }
    }


    private int ObliczCzasPodrozy(Trasa trasa, Samolot samolot)
    {
        // Właściwa implementacja obliczania czasu podróży na podstawie odległości i prędkości samolotu
        return trasa.Dystans / samolot.Zasieg;
    }

    public void ZrobRezerwacje(Lot lot, Klient Klient)
    {
        // Logika dokonywania rezerwacji
    }

    public int GetFlightCount()
    {
        return loty.Count;
    }

    public Lot GetFlightByIndex(int index)
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
        using (StreamWriter writer = new StreamWriter("loty.txt"))
        {
            foreach (Lot lot in loty)
            {
                writer.WriteLine(
                    $"{lot.Samolot.Model},{lot.Trasa.LotniskoWylotu},{lot.Trasa.LotniskoPrzylotu},{lot.CzasWylotu},{lot.CzasPrzylotu}");
            }
        }

        Console.WriteLine("Loty zostały zapisane.");
    }

    public void Odczytaj()
    {
        loty.Clear();

        if (File.Exists("loty.txt"))
        {
            using (StreamReader reader = new StreamReader("loty.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    string[] daneSamolotu = linia.Split(',');
                    if (daneSamolotu.Length == 5)
                    {
                        string model = daneSamolotu[0];
                        string lotniskoWylotu = daneSamolotu[1];
                        string lotniskoPrzylotu = daneSamolotu[2];
                        DateTime czasWylotu;
                        DateTime czasPrzylotu;

                        if (DateTime.TryParseExact(daneSamolotu[3], "dd/MM/yyyy h:mm:ss tt",
                                CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out czasWylotu) &&
                            DateTime.TryParseExact(daneSamolotu[4], "dd/MM/yyyy h:mm:ss tt",
                                CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out czasPrzylotu))
                        {
                            Samolot samolot = samoloty.FirstOrDefault(a => a.Model == model);
                            Trasa trasa = trasy.FirstOrDefault(r =>
                                r.LotniskoWylotu == lotniskoWylotu && r.LotniskoPrzylotu == lotniskoPrzylotu);

                            if (samolot != null && trasa != null)
                            {
                                Lot lot = new Lot(samolot, trasa, czasWylotu, czasPrzylotu);

                                loty.Add(lot);
                            }
                            else
                            {
                                Console.WriteLine($"Niepoprawne dane lotu: {linia}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Niepoprawne dane lotu: {linia}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Niepoprawne dane lotu: {linia}");
                    }
                }
            }

            Console.WriteLine("Dane lotu odczytane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono pliku z lotami.");
        }
    }
}