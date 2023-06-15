namespace UslugiLotnicze;

class TextInterface
{
    private ReservationSystem reservationSystem;

    public TextInterface()
    {
        reservationSystem = new ReservationSystem();
    }

    // Metoda wyświetlająca menu
    public void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Manage Aircrafts");
            Console.WriteLine("2. Manage Customers");
            Console.WriteLine("3. Manage Routes");
            Console.WriteLine("4. Generate Flights");
            Console.WriteLine("5. Make Reservation");
            Console.WriteLine("6. Save State");
            Console.WriteLine("7. Load State");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageAircrafts();
                    break;
                case "2":
                    ManageCustomers();
                    break;
                case "3":
                    ManageRoutes();
                    break;
                case "4":
                    GenerateFlights();
                    break;
                case "5":
                    MakeReservation();
                    break;
                case "6":
                    SaveState();
                    break;
                case "7":
                    LoadState();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

        // Metoda obsługująca zarządzanie samolotami
        private void ManageAircrafts()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Aircraft");
            Console.WriteLine("2. Remove Aircraft");
            Console.WriteLine("3. View Aircrafts");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAircraft();
                    break;
                case "2":
                    RemoveAircraft();
                    break;
                case "3":
                    ViewAircrafts();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // Metoda dodająca samolot
        private void AddAircraft()
        {
            Console.WriteLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Enter Range: ");
            int range = int.Parse(Console.ReadLine());

            Aircraft aircraft = new Aircraft(model, capacity, range);

            reservationSystem.AddAircraft(aircraft);
            Console.WriteLine("Aircraft added.");
        }

        // Metoda usuwająca samolot
        private void RemoveAircraft()
        {
            Console.WriteLine();
            ViewAircrafts();
            Console.Write("Enter the index of the aircraft to remove: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < reservationSystem.GetAircraftCount())
            {
                Aircraft aircraft = reservationSystem.GetAircraftByIndex(index);
                reservationSystem.RemoveAircraft(aircraft);
                Console.WriteLine("Aircraft removed.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // Metoda wyświetlająca samoloty
        private void ViewAircrafts()
        {
            Console.WriteLine();
            reservationSystem.ViewAircrafts();
        }

        // Metoda obsługująca zarządzanie klientami
        private void ManageCustomers()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. View Customers");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    RemoveCustomer();
                    break;
                case "3":
                    ViewCustomers();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // Metoda dodająca klienta
        private void AddCustomer()
        {
            Console.WriteLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Type: ");
            string type = Console.ReadLine();

            Customer customer = new Customer(name, type);

            reservationSystem.AddCustomer(customer);
            Console.WriteLine("Customer added.");
        }

        // Metoda usuwająca klienta
        private void RemoveCustomer()
        {
            Console.WriteLine();
            ViewCustomers();
            Console.Write("Enter the index of the customer to remove: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < reservationSystem.GetCustomerCount())
            {
                Customer customer = reservationSystem.GetCustomerByIndex(index);
                reservationSystem.RemoveCustomer(customer);
                Console.WriteLine("Customer removed.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // Metoda wyświetlająca klientów
        private void ViewCustomers()
        {
            Console.WriteLine();
            reservationSystem.ViewCustomers();
        }

        // Metoda obsługująca zarządzanie trasami
        private void ManageRoutes()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Route");
            Console.WriteLine("2. Remove Route");
            Console.WriteLine("3. View Routes");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRoute();
                    break;
                case "2":
                    RemoveRoute();
                    break;
                case "3":
                    ViewRoutes();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        // Metoda dodająca trasę
        private void AddRoute()
        {
            Console.WriteLine();
            Console.Write("Enter Departure Airport: ");
            string departureAirport = Console.ReadLine();
            Console.Write("Enter Arrival Airport: ");
            string arrivalAirport = Console.ReadLine();
            Console.Write("Enter Distance: ");
            int distance = int.Parse(Console.ReadLine());

            Route route = new Route(departureAirport, arrivalAirport, distance);

            reservationSystem.AddRoute(route);
            Console.WriteLine("Route added.");
        }

        // Metoda usuwająca trasę
        private void RemoveRoute()
        {
            Console.WriteLine();
            ViewRoutes();
            Console.Write("Enter the index of the route to remove: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < reservationSystem.GetRouteCount())
            {
                Route route = reservationSystem.GetRouteByIndex(index);
                reservationSystem.RemoveRoute(route);
                Console.WriteLine("Route removed.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        // Metoda wyświetlająca trasy
        private void ViewRoutes()
        {
            Console.WriteLine();
            reservationSystem.ViewRoutes();
        }

        // Metoda generująca loty
        private void GenerateFlights()
        {
            Console.WriteLine();
            reservationSystem.GenerateFlights();
            Console.WriteLine("Flights generated.");
        }

        // Metoda obsługująca dokonywanie rezerwacji
        private void MakeReservation()
        {
            Console.WriteLine();
            ViewFlights();
            Console.Write("Enter the index of the flight to make a reservation: ");
            int flightIndex = int.Parse(Console.ReadLine());

            if (flightIndex >= 0 && flightIndex < reservationSystem.GetFlightCount())
            {
                Flight flight = reservationSystem.GetFlightByIndex(flightIndex);

                ViewCustomers();
                Console.Write("Enter the index of the customer to make the reservation for: ");
                int customerIndex = int.Parse(Console.ReadLine());

                if (customerIndex >= 0 && customerIndex < reservationSystem.GetCustomerCount())
                {
                    Customer customer = reservationSystem.GetCustomerByIndex(customerIndex);
                    reservationSystem.MakeReservation(flight, customer);
                    Console.WriteLine("Reservation made.");
                }
                else
                {
                    Console.WriteLine("Invalid customer index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid flight index.");
            }
        }

        // Metoda wyświetlająca loty
        private void ViewFlights()
        {
            Console.WriteLine();
            reservationSystem.ViewFlights();
        }

        // Metoda zapisująca stan systemu
        private void SaveState()
        {
            Console.WriteLine();
            reservationSystem.SaveState();
        }

        // Metoda wczytująca stan systemu
        private void LoadState()
        {
            Console.WriteLine();
            reservationSystem.LoadState();
        }
    }