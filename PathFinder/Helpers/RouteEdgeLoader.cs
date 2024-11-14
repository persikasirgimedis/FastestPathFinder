public static class RouteEdgeLoader
{
    public static IEnumerable<RouteEdges> LoadAllEdges(IEnumerable<Route> routes)
    {
        var edges = new List<RouteEdges>();
        foreach (var route in routes)
        {
            var left = edges.FirstOrDefault(x => x.Arrival == route.From);

            if (left == null)
            {
                left = new RouteEdges(route.From);
                edges.Add(left);
            }

            left.AddEdge(route.To, route.Duration);

            var right = edges.FirstOrDefault(x => x.Arrival == route.To);
            if (right == null)
            {
                right = new RouteEdges(route.To);
                edges.Add(right);
            }

            right.AddEdge(route.From, route.Duration);
        }

        return edges;
    }
}
