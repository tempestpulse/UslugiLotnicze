namespace UslugiLotnicze;

class TekstowyInterface
{
    private SystemRezerwacji systemRezerwacji;

    public TekstowyInterface()
    {
        systemRezerwacji = new SystemRezerwacji();
    }

    // Metoda wyświetlająca menu
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
                    ManageAircrafts();
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

        // Metoda obsługująca zarządzanie samolotami
        private void ManageAircrafts()
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

        // Metoda dodająca samolot
        private void DodajSamolot()
        {
            Console.WriteLine();
            Console.Write("Podaj Model: ");
            string model = Console.ReadLine();
            Console.Write("Podaj Rozmiar: ");
            int rozmiar = int.Parse(Console.ReadLine());
            Console.Write("Podaj Zasieg: ");
            int zasieg = int.Parse(Console.ReadLine());

            Samolot samolot = new Samolot(model, rozmiar, zasieg);

            systemRezerwacji.DodajSamolot(samolot);
            Console.WriteLine("Samolot dodany.");
        }

        // Metoda usuwająca samolot
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

        // Metoda wyświetlająca samoloty
        private void WyswietlSamoloty()
        {
            Console.WriteLine();
            systemRezerwacji.WyswietlSamoloty();
        }

        // Metoda obsługująca zarządzanie klientami
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

        // Metoda dodająca klienta
        private void DodajKlienta()
        {
            Console.WriteLine();
            Console.Write("Podaj Imie: ");
            string imie = Console.ReadLine();
            Console.Write("Podaj Typ: ");
            string typ = Console.ReadLine();

            Klient Klient = new Klient(imie, typ);

            systemRezerwacji.DodajKlienta(Klient);
            Console.WriteLine("Klient dodany.");
        }

        // Metoda usuwająca klienta
        private void UsunKlienta()
        {
            Console.WriteLine();
            WyswietlKlientow();
            Console.Write("Podaj index klienta, którego chcesz usunąć: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < systemRezerwacji.GetKlientCount())
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

        // Metoda wyświetlająca klientów
        private void WyswietlKlientow()
        {
            Console.WriteLine();
            systemRezerwacji.WyswietlKlientow();
        }

        // Metoda obsługująca zarządzanie trasami
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

        // Metoda dodająca trasę
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
            Console.WriteLine("Trasa added.");
        }

        // Metoda usuwająca trasę
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

        // Metoda wyświetlająca trasy
        private void WyswietlTrasy()
        {
            Console.WriteLine();
            systemRezerwacji.WyswietlTrasy();
        }

        // Metoda generująca loty
        private void GenerujLoty()
        {
            Console.WriteLine();
            systemRezerwacji.GenerujLoty();
            Console.WriteLine("Loty zostały wygenerowane.");
        }

        // Metoda obsługująca dokonywanie rezerwacji
        private void ZrobRezerwacje()
        {
            Console.WriteLine();
            WyswietlLoty();
            Console.Write("Podaj index lotu, na który chcesz zrobić rezerwację: ");
            int flightIndex = int.Parse(Console.ReadLine());

            if (flightIndex >= 0 && flightIndex < systemRezerwacji.GetFlightCount())
            {
                Lot lot = systemRezerwacji.GetFlightByIndex(flightIndex);

                WyswietlKlientow();
                Console.Write("Podaj index klienta, dla którego chcesz zrobić rezerwację: ");
                int KlientIndex = int.Parse(Console.ReadLine());

                if (KlientIndex >= 0 && KlientIndex < systemRezerwacji.GetKlientCount())
                {
                    Klient Klient = systemRezerwacji.GetKlientByIndex(KlientIndex);
                    systemRezerwacji.ZrobRezerwacje(lot, Klient);
                    Console.WriteLine("Rezerwacja ukończona.");
                }
                else
                {
                    Console.WriteLine("Niepoprawny index klienta.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny index lotu.");
            }
        }

        // Metoda wyświetlająca loty
        private void WyswietlLoty()
        {
            Console.WriteLine();
            systemRezerwacji.WyswietlLoty();
        }

        // Metoda zapisująca stan systemu
        private void Zapisz()
        {
            Console.WriteLine();
            systemRezerwacji.Zapisz();
        }

        // Metoda wczytująca stan systemu
        private void Odczytaj()
        {
            Console.WriteLine();
            systemRezerwacji.Odczytaj();
        }
    }