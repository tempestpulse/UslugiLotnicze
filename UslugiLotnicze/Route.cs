namespace UslugiLotnicze;

class Route
{
    public string DepartureAirport { get; }
    public string ArrivalAirport { get; }
    public int Distance { get; }

    public Route(string departureAirport, string arrivalAirport, int distance)
    {
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
        Distance = distance;
    }
}