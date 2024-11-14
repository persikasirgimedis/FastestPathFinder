namespace ConsoleApp4.Interfaces
{
    public interface IRoutesRepository
    {
        public Task<IEnumerable<RouteRecord>> GetAllAsync();
    }
}
