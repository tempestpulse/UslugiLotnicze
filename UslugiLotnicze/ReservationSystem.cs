namespace UslugiLotnicze;
using System.Globalization;

class ReservationSystem
{
    private List<Aircraft> aircrafts;
    private List<Customer> customers;
    private List<Route> routes;
    private List<Flight> flights;

    public ReservationSystem()
    {
        aircrafts = new List<Aircraft>();
        customers = new List<Customer>();
        routes = new List<Route>();
        flights = new List<Flight>();
    }

    public void AddAircraft(Aircraft aircraft)
    {
        aircrafts.Add(aircraft);
    }

    public void RemoveAircraft(Aircraft aircraft)
    {
        aircrafts.Remove(aircraft);
    }

    public int GetAircraftCount()
    {
        return aircrafts.Count;
    }

    public Aircraft GetAircraftByIndex(int index)
    {
        return aircrafts[index];
    }

    public void ViewAircrafts()
    {
        for (int i = 0; i < aircrafts.Count; i++)
        {
            Aircraft aircraft = aircrafts[i];
            Console.WriteLine(
                $"Aircraft {i}: Model - {aircraft.Model}, Capacity - {aircraft.Capacity}, Range - {aircraft.Range}");
        }
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }

    public int GetCustomerCount()
    {
        return customers.Count;
    }

    public Customer GetCustomerByIndex(int index)
    {
        return customers[index];
    }

    public void ViewCustomers()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            Customer customer = customers[i];
            Console.WriteLine($"Customer {i}: Name - {customer.Name}, Type - {customer.Type}");
        }
    }

    public void AddRoute(Route route)
    {
        routes.Add(route);
    }

    public void RemoveRoute(Route route)
    {
        routes.Remove(route);
    }

    public int GetRouteCount()
    {
        return routes.Count;
    }

    public Route GetRouteByIndex(int index)
    {
        return routes[index];
    }

    public void ViewRoutes()
    {
        for (int i = 0; i < routes.Count; i++)
        {
            Route route = routes[i];
            Console.WriteLine(
                $"Route {i}: Departure Airport - {route.DepartureAirport}, Arrival Airport - {route.ArrivalAirport}, Distance - {route.Distance}");
        }
    }

    public void GenerateFlights()
    {
        foreach (Route route in routes)
        {
            foreach (Aircraft aircraft in aircrafts)
            {
                int travelTime = CalculateTravelTime(route, aircraft);
                if (aircraft.Range < route.Distance)
                {
                    Console.WriteLine(
                        $"Flight not generated for Aircraft {aircraft.Model} and Route {route.DepartureAirport} to {route.ArrivalAirport}. Aircraft range is insufficient.");
                    continue;
                }

                DateTime departureTime = DateTime.Now;
                DateTime arrivalTime = departureTime.AddHours(travelTime);

                Flight flight = new Flight(aircraft, route, departureTime, arrivalTime);

                flights.Add(flight);
                Console.WriteLine(
                    $"Flight generated for Aircraft {aircraft.Model} and Route {route.DepartureAirport} to {route.ArrivalAirport}.");
            }
        }
    }


    private int CalculateTravelTime(Route route, Aircraft aircraft)
    {
        // Właściwa implementacja obliczania czasu podróży na podstawie odległości i prędkości samolotu
        return route.Distance / aircraft.Range;
    }

    public void MakeReservation(Flight flight, Customer customer)
    {
        // Logika dokonywania rezerwacji
    }

    public int GetFlightCount()
    {
        return flights.Count;
    }

    public Flight GetFlightByIndex(int index)
    {
        return flights[index];
    }

    public void ViewFlights()
    {
        for (int i = 0; i < flights.Count; i++)
        {
            Flight flight = flights[i];
            Console.WriteLine(
                $"Flight {i}: Aircraft - {flight.Aircraft.Model}, Route - {flight.Route.DepartureAirport} to {flight.Route.ArrivalAirport}, Departure Time - {flight.DepartureTime}, Arrival Time - {flight.ArrivalTime}");
        }
    }

    public void SaveState()
    {
        using (StreamWriter writer = new StreamWriter("flights.txt"))
        {
            foreach (Flight flight in flights)
            {
                writer.WriteLine(
                    $"{flight.Aircraft.Model},{flight.Route.DepartureAirport},{flight.Route.ArrivalAirport},{flight.DepartureTime},{flight.ArrivalTime}");
            }
        }

        Console.WriteLine("Flight data saved.");
    }

    public void LoadState()
    {
        flights.Clear();

        if (File.Exists("flights.txt"))
        {
            using (StreamReader reader = new StreamReader("flights.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] flightData = line.Split(',');
                    if (flightData.Length == 5)
                    {
                        string model = flightData[0];
                        string departureAirport = flightData[1];
                        string arrivalAirport = flightData[2];
                        DateTime departureTime;
                        DateTime arrivalTime;

                        if (DateTime.TryParseExact(flightData[3], "dd/MM/yyyy h:mm:ss tt",
                                CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out departureTime) &&
                            DateTime.TryParseExact(flightData[4], "dd/MM/yyyy h:mm:ss tt",
                                CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out arrivalTime))
                        {
                            Aircraft aircraft = aircrafts.FirstOrDefault(a => a.Model == model);
                            Route route = routes.FirstOrDefault(r =>
                                r.DepartureAirport == departureAirport && r.ArrivalAirport == arrivalAirport);

                            if (aircraft != null && route != null)
                            {
                                Flight flight = new Flight(aircraft, route, departureTime, arrivalTime);

                                flights.Add(flight);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid flight data: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid flight data: {line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid flight data: {line}");
                    }
                }
            }

            Console.WriteLine("Flight data loaded.");
        }
        else
        {
            Console.WriteLine("No saved flight data found.");
        }
    }
}