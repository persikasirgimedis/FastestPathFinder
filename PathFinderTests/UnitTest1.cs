[TestFixture]
public class PathFinderTest
{
    private string _ltPath = @"Klaipeda,Kaunas,2:00
Vilnius,Kaunas,1:00
Kaunas,Ukmerge,1:00
Vilnius,Ukmerge,1:00
Klaipeda,Panevezys,3:00
Panevezys,Vilnius,2:00";

    [Test]
    public async Task FindFastestPath()
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

        var result = finder.LoadVertices(new City("Vilnius"));
        var vertex = result.FirstOrDefault(x => x.Point == new City("Klaipeda"));
        Assert.NotNull(vertex);
        Assert.AreEqual(TimeSpan.FromMinutes(180), vertex.MinDuration);

        var paths = string.Join(',', vertex.GetDirections());
        Assert.AreEqual("Vilnius,Kaunas,Klaipeda", paths);
    }

    [Test]
    public async Task FindFastestPath_LTPathArray_Bug()
    {
        var finder = new PathFinder.PathFinder();
        var result = await finder.FindFastestPath("Vilnius", "Klaipeda", _ltPath);
        Assert.AreEqual(TimeSpan.FromMinutes(210), result.Item1);
        Assert.AreEqual("Vilnius,Kaunas,Klaipeda", result.Item2);
    }
}