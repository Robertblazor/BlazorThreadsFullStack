
namespace ThreadsLib.DataAccess
{
    public class MongoMetricInternalCollection : IMetricInternalCollection
    {
        private readonly IMongoCollection<MetricInternal> _metricInternals;
        private readonly IMemoryCache _cache;
        private const string CacheName = "MetricInternalData";
        public MongoMetricInternalCollection(IDbConnection db, IMemoryCache cache)
        {
            _metricInternals = db.MetricInternalCollection;
            _cache = cache;
        }
        public async Task<List<MetricInternal>> GetAllMetricInternalsAsync()
        {
            var output = _cache.Get<List<MetricInternal>>(CacheName);
            if (output == null)
            {
                var results = await _metricInternals.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }
        public async Task<List<MetricInternal>> GetMetricInternalsByDesignitionAsync(string designition)
        {
            var results = await GetAllMetricInternalsAsync();
            return results.Where(mi => mi.CustomThreadDesignition == designition).ToList();
        }
        public async Task<MetricInternal> GetMetricInternalByInternalId(int id)
        {
            var results = await GetAllMetricInternalsAsync();
            return results.FirstOrDefault(mi => mi.InternalId == id);
        }
        public Task CreateMetricInternalAsync(MetricInternal metricInternal)
        {
            return _metricInternals.InsertOneAsync(metricInternal);
        }
    }
}
