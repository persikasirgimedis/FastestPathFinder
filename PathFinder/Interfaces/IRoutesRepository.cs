namespace ConsoleApp4.Interfaces
{
    public interface IRoutesRepository
    {
        public IEnumerable<RouteRecord> GetAll();
    }
}
