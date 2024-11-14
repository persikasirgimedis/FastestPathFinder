using ConsoleApp4.Interfaces;

public class FastestPathService(IRoutesRepository routesRepository) : IFastestPathService
{
    public TimeSpan FindFastestPathDuration(City arrival, City departure)
    {
        var fastes = FindFastestVertex(arrival, departure);

        if (fastes == null)
        {
            return default;
        }

        return fastes.MinDuration;
    }

    public Vertex? FindFastestVertex(City arrival, City departure)
    {
        var vertices = FindFastestPaths(arrival);

        var vertix = vertices.FirstOrDefault(x => x.Point == departure);

        return vertix;
    }

    public IEnumerable<Vertex> FindFastestPaths(City arrival)
    {
        var routes = routesRepository.GetAll();
        var edges = RouteEdgeLoader.LoadAllEdges(routes.Select(x => x.ToDomain()));

        var finder = new FastestPathFinder(edges);

        var vertices = finder.LoadVertices(arrival);
        return vertices;
    }
}