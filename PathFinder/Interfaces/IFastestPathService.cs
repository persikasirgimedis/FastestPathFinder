public interface IFastestPathService
{
    Task<Vertex?> FindFastestVertexAsync(City arrival, City departure);

    Task<TimeSpan> FindFastestPathDurationAsync(City arrival, City departure);

    Task<IEnumerable<Vertex>> FindFastestPathsAsync(City arrival);
}
