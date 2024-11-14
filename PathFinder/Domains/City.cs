public record City
{
    public City(string name)
    {
        Name = name;
    }

    public string Name { get; }
}