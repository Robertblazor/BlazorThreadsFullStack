
namespace ThreadsLib.DataAccess
{
    public class MongoStandardInternalCollection : IStandardInternalCollection
    {
        private readonly IMongoCollection<StandardInternal> _standardInternals;
        private readonly IMemoryCache _cache;
        private const string CacheName = "StandardInternalData";
        public MongoStandardInternalCollection(IDbConnection db, IMemoryCache cache)
        {
            _standardInternals = db.StandardInternalCollection;
            _cache = cache;
        }
        public async Task<List<StandardInternal>> GetAllStandardInternalsAsync()
        {
            var output = _cache.Get<List<StandardInternal>>(CacheName);
            if (output == null)
            {
                var results = await _standardInternals.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }
        public async Task<List<StandardInternal>> GetStandardInternalsByDesignition(string designition)
        {
            var results = await GetAllStandardInternalsAsync();
            return results.Where(si => si.CustomThreadDesignition == designition).ToList();
        }
        public async Task<StandardInternal> GetStandardInternalByInternalId(int id)
        {
            var results = await GetAllStandardInternalsAsync();
            return results.Where(si => si.InternalId == id).FirstOrDefault();
        }
        public Task CreateStandardInternalAsync(StandardInternal standardInternal)
        {
            return _standardInternals.InsertOneAsync(standardInternal);
        }
    }
}
