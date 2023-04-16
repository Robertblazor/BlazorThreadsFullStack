
namespace ThreadsLib.DataAccess
{
    public class MongoMetricExternalCollection : IMetricExternalCollection
    {
        private readonly IMongoCollection<MetricExternal> _metricExternals;
        private readonly IMemoryCache _cache;
        private const string cacheName = "MetricExternalData";
        public MongoMetricExternalCollection(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _metricExternals = db.MetricExternalCollection;
        }
        public async Task<List<MetricExternal>> GetAllMetricExternalsAsync()
        {
            var output = _cache.Get<List<MetricExternal>>(cacheName);
            if (output == null)
            {
                var results = await _metricExternals.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }
        public Task CreateMetricExternalAsync(MetricExternal metricExternal)
        {
            return _metricExternals.InsertOneAsync(metricExternal);
        }
        public async Task<List<MetricExternal>> GetMetricExternalsByDesignition(string designition)
        {
            var results = await GetAllMetricExternalsAsync();
            return results.Where(me => me.CustomThreadDesignition == designition).ToList();
        }
        public async Task<MetricExternal> GetMetricExternalByInternalId(int id)
        {
            var results = await GetAllMetricExternalsAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return results.FirstOrDefault(me => me.InternalId == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
