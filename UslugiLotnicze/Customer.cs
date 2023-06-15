namespace UslugiLotnicze;

class Customer
{
    public string Name { get; }
    public string Type { get; }

    public Customer(string name, string type)
    {
        Name = name;
        Type = type;
    }
}