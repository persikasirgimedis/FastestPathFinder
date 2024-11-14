public class RouteEdge
{
    public City Departure { get; }
    public TimeSpan Duration { get; }

    public RouteEdge(City departure, TimeSpan duration)
    {
        Departure = departure;
        Duration = duration;
    }

    public RouteEdge WithNewDuration(TimeSpan duration)
    {
        return new RouteEdge(Departure, duration);
    }
}
