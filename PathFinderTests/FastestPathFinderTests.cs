[TestFixture]
public class FastestPathFinderTests
{
    [Test]
    public async Task FindFastestPathDuration()
    {
        var finder = SetupFinderAndPopulateRoutes();

        var vertices = finder.LoadVertices(new City("Vilnius"));
        var vertex = vertices.FirstOrDefault(x => x.Point == new City("Klaipeda"));

        Assert.NotNull(vertex);
        Assert.AreEqual(TimeSpan.FromMinutes(180), vertex.MinDuration);
    }

    [Test]
    public async Task FindFastestPathDirections()
    {
        var finder = SetupFinderAndPopulateRoutes();

        var vertices = finder.LoadVertices(new City("Vilnius"));
        var vertex = vertices.FirstOrDefault(x => x.Point == new City("Klaipeda"));

        Assert.NotNull(vertex);
        var paths = string.Join(',', vertex.GetDirections());
        Assert.AreEqual("Vilnius,Kaunas,Klaipeda", paths);
    }

    private static FastestPathFinder SetupFinderAndPopulateRoutes()
    {
        var routes = new List<RouteRecord>
        {
            new("Klaipeda", "Kaunas", new TimeSpan(0, 2, 0, 0)),
            new("Vilnius", "Kaunas", new TimeSpan(0, 1, 0, 0)),
            new("Kaunas", "Ukmerge", new TimeSpan(0, 1, 0, 0)),
            new("Vilnius", "Ukmerge", new TimeSpan(0, 1, 0, 0)),
            new("Klaipeda", "Panevezys", new TimeSpan(0, 3, 0, 0)),
            new("Panevezys", "Vilnius", new TimeSpan(0, 2, 0, 0))
        };

        var edges = RouteEdgeLoader.LoadAllEdges(routes.Select(x => x.ToDomain()));
        var finder = new FastestPathFinder(edges);
        return finder;
    }
}