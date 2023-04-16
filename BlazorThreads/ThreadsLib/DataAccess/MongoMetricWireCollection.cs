
namespace ThreadsLib.DataAccess
{
    public class MongoMetricWireCollection : IMetricWireCollection
    {
        private readonly IMemoryCache _cache;
        private readonly IMongoCollection<MetricWire> _metricWires;
        private const string CacheName = "MetricWire";
        public MongoMetricWireCollection(IDbConnection db, IMemoryCache cache)
        {
            _metricWires = db.MetricWireCollection;
            _cache = cache;
        }
        public async Task<List<MetricWire>> GetAllMetricWiresAsync()
        {
            var output = _cache.Get<List<MetricWire>>(CacheName);
            if (output == null)
            {
                var results = await _metricWires.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromDays(1));

            }
            return output;
        }
        public async Task<MetricWire> GetMetricWireAsync(double pitch)
        {
            var results = await GetAllMetricWiresAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return results.FirstOrDefault(mw => mw.Pitch == pitch);
#pragma warning restore CS8603 // Possible null reference return.
        }
        public Task CreateMetricWireAsync(MetricWire metricWire)
        {
            return _metricWires.InsertOneAsync(metricWire);
        }
    }
}
