public class FastestPathFinder
{
    public IEnumerable<RouteEdges> Edges { get; }

    public FastestPathFinder(IEnumerable<RouteEdges> edges)
    {
        Edges = edges;
    }

    public IEnumerable<Vertex> LoadVertices(City startingPoint)
    {
        var vertices = InitiateVerteces(Edges);

        var root = vertices.FirstOrDefault(x => x.Point == startingPoint) ?? throw new Exception();
        root.AsRoot();

        vertices = RenewFastestPathLinks(vertices, root);
        return vertices;
    }

    private static IReadOnlyList<Vertex> InitiateVerteces(IEnumerable<RouteEdges> routeEdges) =>
        routeEdges
        .Select(x => new Vertex(x.Arrival))
        .ToList();

    private IReadOnlyList<Vertex> RenewFastestPathLinks(IReadOnlyList<Vertex> vertices, Vertex vertex)
    {
        var neighbors = Edges.FirstOrDefault(x => x.Arrival == vertex.Point) ?? throw new Exception();

        foreach (var neighbor in neighbors.Edges)
        {
            var neighborVertex = vertices.FirstOrDefault(x => x.Point == neighbor.Departure && !x.IsVisited);

            if (neighborVertex != null)
            {
                var newDuration = vertex.MinDuration + neighbor.Duration;

                if (newDuration < neighborVertex.MinDuration)
                {
                    neighborVertex.RenewPath(newDuration, vertex);
                }
            }
        }

        vertex.Visit();

        var next = SelectNextClosestVertex(vertices);

        if (next == null)
        {
            return vertices;
        }

        return RenewFastestPathLinks(vertices, next);
    }

    private static Vertex? SelectNextClosestVertex(IReadOnlyList<Vertex> vertices)
    {
        return vertices
            .Where(x => !x.IsVisited)
            .OrderBy(x => x.MinDuration)
            .FirstOrDefault();
    }
}