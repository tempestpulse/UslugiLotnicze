namespace UslugiLotnicze;

class Flight
{
    public Aircraft Aircraft { get; }
    public Route Route { get; }
    public DateTime DepartureTime { get; }
    public DateTime ArrivalTime { get; }

    public Flight(Aircraft aircraft, Route route, DateTime departureTime, DateTime arrivalTime)
    {
        Aircraft = aircraft;
        Route = route;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }
}