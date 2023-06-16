class Samolot
{
    public string Model { get; }
    public int Rozmiar { get; }
    public int Zasieg { get; }

    public Samolot(string model, int rozmiar, int zasieg)
    {
        Model = model;
        Rozmiar = rozmiar;
        Zasieg = zasieg;
    }
}