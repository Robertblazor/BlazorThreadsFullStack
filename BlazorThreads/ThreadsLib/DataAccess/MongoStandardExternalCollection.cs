
namespace ThreadsLib.DataAccess
{
    public class MongoStandardExternalCollection : IStandardExternalCollection
    {
        private readonly IMongoCollection<StandardExternal> _standardExternal;
        private readonly IMemoryCache _cache;
        private const string CacheName = "StandardExternalData";
        public MongoStandardExternalCollection(IDbConnection db, IMemoryCache cache)
        {
            _standardExternal = db.StandardExternalCollection;
            _cache = cache;
        }
        public async Task<List<StandardExternal>> GetAllStandardExternalsAsync()
        {
            var output = _cache.Get<List<StandardExternal>>(CacheName);
            if (output == null)
            {
                var results = await _standardExternal.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }
        public async Task<List<StandardExternal>> GetStandardExternalsByDesignitionAsync(string designition)
        {
            var results = await GetAllStandardExternalsAsync();
            return results.Where(se => se.CustomThreadDesignition == designition).ToList();
        }
        public async Task<StandardExternal> GetStandardExternalByInternalIdAsync(int id)
        {
            var results = await GetAllStandardExternalsAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return results.Where((se) => se.InternalId == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }
        public Task CreateStandardExternalAsync(StandardExternal standardExternal)
        {
            return _standardExternal.InsertOneAsync(standardExternal);
        }
    }
}
