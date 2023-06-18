namespace UslugiLotnicze;

class TekstowyInterface
{
    public SystemRezerwacji systemRezerwacji;

    public TekstowyInterface()
    {
        systemRezerwacji = new SystemRezerwacji();
    }


    public void PokazMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Zarzadząj Samolotami");
            Console.WriteLine("2. Zarzadząj Klientami");
            Console.WriteLine("3. Zarządzaj Trasami");
            Console.WriteLine("4. Generuj Lot");
            Console.WriteLine("5. Zrób rezerwację");
            Console.WriteLine("6. Zapisz");
            Console.WriteLine("7. Odczytaj");
            Console.WriteLine("8. Wyjdź");
            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    ZarzadzajSamolotami();
                    break;
                case "2":
                    ZarzadzajKlientami();
                    break;
                case "3":
                    ZarzadzajTrasami();
                    break;
                case "4":
                    GenerujLoty();
                    break;
                case "5":
                    ZrobRezerwacje();
                    break;
                case "6":
                    Zapisz();
                    break;
                case "7":
                    Odczytaj();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }


    private void ZarzadzajSamolotami()
    {
        Console.WriteLine();
        Console.WriteLine("1. Dodaj Samolot");
        Console.WriteLine("2. Usuń Samolot");
        Console.WriteLine("3. Wyświetl Samoloty");
        Console.Write("Wybierz opcję: ");
        string wybor = Console.ReadLine();

        switch (wybor)
        {
            case "1":
                DodajSamolot();
                break;
            case "2":
                UsunSamolot();
                break;
            case "3":
                WyswietlSamoloty();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                break;
        }
    }


    private void DodajSamolot()
    {
        Console.WriteLine();
        Console.WriteLine("1. Mały");
        Console.WriteLine("2. Średni");
        Console.WriteLine("3. Duży");
        Console.Write("Podaj typ samolotu: ");
        string typ = Console.ReadLine();
        Console.Write("Podaj model samolotu: ");
        string model = Console.ReadLine();

        int rozmiar = 0;
        int zasieg = 0;

        switch (typ)
        {
            case "1":
                rozmiar = 2;
                zasieg = 1000;
                break;
            case "2":
                rozmiar = 1000;
                zasieg = 2000;
                break;
            case "3":
                rozmiar = 1500;
                zasieg = 3000;
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór typu samolotu.");
                return;
        }

        Samolot samolot = new Samolot(model, rozmiar, zasieg);

        systemRezerwacji.DodajSamolot(samolot);
        Console.WriteLine("Samolot dodany.");
    }

    private void UsunSamolot()
    {
        Console.WriteLine();
        WyswietlSamoloty();
        Console.Write("Podaj index samolotu, który chcesz usunąć: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < systemRezerwacji.GetSamolotyIlosc())
        {
            Samolot samolot = systemRezerwacji.GetSamolotIndex(index);
            systemRezerwacji.UsunSamolot(samolot);
            Console.WriteLine("Samolot usunięty.");
        }
        else
        {
            Console.WriteLine("Niepoprawny index.");
        }
    }


    private void WyswietlSamoloty()
    {
        Console.WriteLine();
        systemRezerwacji.WyswietlSamoloty();
    }


    private void ZarzadzajKlientami()
    {
        Console.WriteLine();
        Console.WriteLine("1. Dodaj klienta");
        Console.WriteLine("2. Usuń klienta");
        Console.WriteLine("3. Wyświetl Klientów");
        Console.Write("Wybierz opcję: ");
        string wybor = Console.ReadLine();

        switch (wybor)
        {
            case "1":
                DodajKlienta();
                break;
            case "2":
                UsunKlienta();
                break;
            case "3":
                WyswietlKlientow();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                break;
        }
    }


    private void DodajKlienta()
    {
        Console.WriteLine();
        Console.WriteLine("1. Indywidualny");
        Console.WriteLine("2. Pośrednik firmy");
        Console.Write("Wybierz typ klienta: ");
        string wybor = Console.ReadLine();
        string imie;
        string nazwisko;
        string nazwa_Firmy;
        string nip_Firmy;


        switch (wybor)
        {
            case "1":

                Console.WriteLine();
                Console.Write("Podaj imię klienta: ");
                imie = Console.ReadLine();
                Console.Write("Podaj nazwisko klienta: ");
                nazwisko = Console.ReadLine();
                Klient indywidualny = new Indywidualny(imie, nazwisko);
                systemRezerwacji.DodajKlienta(indywidualny);
                Console.WriteLine("Klient dodany.");
                break;
            case "2":
                Console.WriteLine();

                Console.Write("Podaj nazwę firmy: ");
                nazwa_Firmy = Console.ReadLine();
                Console.Write("Podaj nip firmy: ");
                nip_Firmy = Console.ReadLine();
                Klient posrednikFirmy = new PosrednikFirmy(nazwa_Firmy, nip_Firmy);
                systemRezerwacji.DodajKlienta(posrednikFirmy);
                Console.WriteLine("Klient dodany.");
                break;
            default:
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                break;
        }
    }




    private void UsunKlienta()
    {
        Console.WriteLine();
        WyswietlKlientow();
        Console.Write("Podaj index klienta, którego chcesz usunąć: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < systemRezerwacji.GetKlientIlosc())
        {
            Klient Klient = systemRezerwacji.GetKlientByIndex(index);
            systemRezerwacji.UsunKlienta(Klient);
            Console.WriteLine("Klient usunięty.");
        }
        else
        {
            Console.WriteLine("Niepoprawny index.");
        }
    }


    private void WyswietlKlientow()
    {
        Console.WriteLine();
        systemRezerwacji.WyswietlKlientow();
    }


    private void ZarzadzajTrasami()
    {
        Console.WriteLine();
        Console.WriteLine("1. Dodaj trasę");
        Console.WriteLine("2. Usuń trasę");
        Console.WriteLine("3. Wyświetl Trasy");
        Console.Write("Wybierz opcję: ");
        string wybor = Console.ReadLine();

        switch (wybor)
        {
            case "1":
                DodajTrase();
                break;
            case "2":
                UsunTrase();
                break;
            case "3":
                WyswietlTrasy();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                break;
        }
    }


    private void DodajTrase()
    {
        Console.WriteLine();
        Console.Write("Dodaj lotnisko wylotu: ");
        string lotniskoWylotu = Console.ReadLine();
        Console.Write("Dodaj lotnisko przylotu: ");
        string lotniskoPrzylotu = Console.ReadLine();
        Console.Write("Dodaj dystans: ");
        int dystans = int.Parse(Console.ReadLine());

        Trasa trasa = new Trasa(lotniskoWylotu, lotniskoPrzylotu, dystans);

        systemRezerwacji.DodajTrase(trasa);
        Console.WriteLine("Trasa dodana.");
    }


    private void UsunTrase()
    {
        Console.WriteLine();
        WyswietlTrasy();
        Console.Write("Podaj index trasy, którą chcesz usunąć: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < systemRezerwacji.GetIloscTras())
        {
            Trasa trasa = systemRezerwacji.GetIndexTrasy(index);
            systemRezerwacji.UsunTrase(trasa);
            Console.WriteLine("Trasa usunięta.");
        }
        else
        {
            Console.WriteLine("Niepoprawny index.");
        }
    }


    private void WyswietlTrasy()
    {
        Console.WriteLine();
        systemRezerwacji.WyswietlTrasy();
    }


    private void GenerujLoty()
    {
        Console.WriteLine();
        systemRezerwacji.GenerujLoty();
        Console.WriteLine("Loty zostały wygenerowane.");
    }


    private void ZrobRezerwacje()
    {
        Console.WriteLine();
        WyswietlLoty();
        Console.Write("Podaj index lotu, na który chcesz zrobić rezerwację: ");
        int LotIndex = int.Parse(Console.ReadLine());


        if (LotIndex >= 0 && LotIndex < systemRezerwacji.GetLotyIlosc())
        {



            Lot lot = systemRezerwacji.GetLotByIndex(LotIndex);
            Samolot samolotNaTrase = lot.Samolot;

            if (systemRezerwacji.iloscKlientowNaLot(LotIndex) >= samolotNaTrase.Rozmiar)
            {
                Console.Write("Nie ma wolnych miejsc w Samolocie");

            }

            else
            {

                WyswietlKlientow();
                Console.Write("Podaj index klienta, dla którego chcesz zrobić rezerwację: ");
                int KlientIndex = int.Parse(Console.ReadLine());

                if (KlientIndex >= 0 && KlientIndex < systemRezerwacji.GetKlientIlosc())
                {

                    Klient Klient = systemRezerwacji.GetKlientByIndex(KlientIndex);
                    if (Klient.getIdLotu() != -1)
                    {
                        Console.WriteLine("Ten klient został przypisany do innego lotu");
                    }
                    else
                    {
                        systemRezerwacji.ZrobRezerwacje(Klient, LotIndex);
                        Console.WriteLine("Rezerwacja ukończona.");
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny index klienta.");
                }
            }
        }
        else
        {
            Console.WriteLine("Niepoprawny index lotu.");
        }
    }


    private void WyswietlLoty()
    {
        Console.WriteLine();
        systemRezerwacji.WyswietlLoty();
    }


    private void Zapisz()
    {
        Console.WriteLine();
        systemRezerwacji.Zapisz();
    }


    private void Odczytaj()
    {
        Console.WriteLine();
        systemRezerwacji.Odczytaj();

        foreach (Lot lot in systemRezerwacji.loty)
        {

            Console.WriteLine(lot.CzasWylotu);
        }
    }
}