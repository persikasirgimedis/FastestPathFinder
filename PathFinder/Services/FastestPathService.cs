using ConsoleApp4.Interfaces;

public class FastestPathService(IRoutesRepository routesRepository) : IFastestPathService
{
    public async Task<TimeSpan> FindFastestPathDurationAsync(City arrival, City departure)
    {
        var fastes = await FindFastestVertexAsync(arrival, departure);

        if (fastes == null)
        {
            return default;
        }

        return fastes.MinDuration;
    }

    public async Task<Vertex?> FindFastestVertexAsync(City arrival, City departure)
    {
        var vertices = await FindFastestPathsAsync(arrival);

        var fastes = vertices.FirstOrDefault(x => x.Point == departure);

        return fastes;
    }

    public async Task<IEnumerable<Vertex>> FindFastestPathsAsync(City arrival)
    {
        var routes = await routesRepository.GetAllAsync();
        var edges = RouteEdgeLoader.LoadAllEdges(routes.Select(x => x.ToDomain()));

        var finder = new FastestPathFinder(edges);

        var vertices = finder.LoadVertices(arrival);
        return vertices;
    }
}