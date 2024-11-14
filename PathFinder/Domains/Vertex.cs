public class Vertex
{
    public Vertex(City point)
    {
        Point = point;
        IsVisited = false;
        MinDuration = TimeSpan.MaxValue;
    }

    public void AsRoot()
    {
        MinDuration = TimeSpan.Zero;
    }

    public void Visit()
    {
        IsVisited = true;
    }

    public void RenewPath(TimeSpan newDuration, Vertex vertex)
    {
        MinDuration = newDuration;
        Previous = vertex;
    }

    public City Point { get; }

    public TimeSpan MinDuration { get; private set; }

    public bool IsVisited { get; private set; }

    public Vertex? Previous { get; private set; }

    public IReadOnlyList<string> GetDirections()
    {
        var directions = GivePathsRecursive(new List<string>(), this);
        directions.Reverse();
        return directions;
    }

    private static List<string> GivePathsRecursive(List<string> directions, Vertex vertex)
    {
        directions.Add(vertex.Point.Name);

        if (vertex.Previous != null)
        {
            GivePathsRecursive(directions, vertex.Previous);
        }

        return directions;
    }
}