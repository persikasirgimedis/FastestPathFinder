public class RouteEdges
{
    public RouteEdges(City arrival)
    {
        Edges = new List<RouteEdge>();
        Arrival = arrival;
    }

    public RouteEdges(City arrival, IEnumerable<RouteEdge> edges)
    {
        Edges = edges.ToList();
        Arrival = arrival;
    }


    public List<RouteEdge> Edges = new List<RouteEdge>();
    public City Arrival { get; set; }

    public void AddEdge(City departure, TimeSpan duration)
    {
        if (Arrival == departure)
        {
            return;
        }

        var edge = Edges.FirstOrDefault(x => x.Departure == departure);

        if (edge != null)
        {
            edge.WithNewDuration(duration);
        }
        else
        {
            Edges.Add(new RouteEdge(departure, duration));
        }
    }
}