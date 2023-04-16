
namespace ThreadsLib.DataAccess
{
    public class MongoStandardWireCollection : IStandardWireCollection
    {
        private readonly IMongoCollection<StandardWire> _standardWires;
        private readonly IMemoryCache _cache;
        private const string CacheName = "StandardWireData";
        public MongoStandardWireCollection(IDbConnection db, IMemoryCache cache)
        {
            _standardWires = db.StandardWireCollection;
            _cache = cache;
        }
        public async Task<List<StandardWire>> GetAllStandardWiresAsync()
        {
            var output = _cache.Get<List<StandardWire>>(CacheName);
            if (output == null)
            {
                var results = await _standardWires.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }
        public async Task<StandardWire> GetStandardWiresByPitchAsync(double pitch)
        {
            var results = await GetAllStandardWiresAsync();
            return results.FirstOrDefault(sw => sw.ThreadPerInch == pitch);
        }
        public Task CreateStandardWireAsync(StandardWire standardWire)
        {
            return _standardWires.InsertOneAsync(standardWire);
        }
    }
}
