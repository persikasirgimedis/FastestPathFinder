public static class DomainMapExtensions
{
    public static Route ToDomain(this RouteRecord route)
    {
        return new Route(new City(route.From), new City(route.To), route.Duration);
    }
}