public interface IFastestPathService
{
    Vertex? FindFastestVertex(City arrival, City departure);

    TimeSpan FindFastestPathDuration(City arrival, City departure);

    IEnumerable<Vertex> FindFastestPaths(City arrival);
}
