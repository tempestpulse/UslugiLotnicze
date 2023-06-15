namespace UslugiLotnicze;

class Aircraft
{
    public string Model { get; }
    public int Capacity { get; }
    public int Range { get; }

    public Aircraft(string model, int capacity, int range)
    {
        Model = model;
        Capacity = capacity;
        Range = range;
    }
}