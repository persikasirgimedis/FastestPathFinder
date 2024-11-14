using ConsoleApp4.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace ConsoleApp4.Repositories
{
    public class RoutesCsvRepository : IRoutesRepository
    {
        private readonly string _filePath;
        public RoutesCsvRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<RouteRecord> GetAll()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                TrimOptions = TrimOptions.Trim
            };

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<RouteRecord>();
            return records.ToList().AsEnumerable();
        }
    }
}