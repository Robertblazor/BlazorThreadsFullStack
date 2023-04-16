namespace ThreadsLib.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";
        public string DbName { get; private set; }
        public string MetricExternalCollectionName { get; private set; } = "Metric_External_ISO";
        public string MetricInternalCollectionName { get; private set; } = "Metric_Internal_ISO";
        public string MetricWireCollectionName { get; private set; } = "MetricWire";
        public string StandardExternalCollectionName { get; private set; } = "Standard_External_ANSI";
        public string StandardInternalCollectionName { get; private set; } = "Standard_Internal_ANSI";
        public string StandardWireCollectionName { get; private set; } = "StandardWire";
        public string UserCollectionName { get; private set; } = "User_Collection";
        public MongoClient Client { get; private set; }
        public IMongoCollection<MetricExternal> MetricExternalCollection { get; private set; }
        public IMongoCollection<MetricInternal> MetricInternalCollection { get; private set; }
        public IMongoCollection<MetricWire> MetricWireCollection { get; private set; }
        public IMongoCollection<StandardExternal> StandardExternalCollection { get; private set; }
        public IMongoCollection<StandardInternal> StandardInternalCollection { get; private set; }
        public IMongoCollection<StandardWire> StandardWireCollection { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }
        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            MetricExternalCollection = _db.GetCollection<MetricExternal>(MetricExternalCollectionName);
            MetricInternalCollection = _db.GetCollection<MetricInternal>(MetricInternalCollectionName);
            MetricWireCollection = _db.GetCollection<MetricWire>(MetricWireCollectionName);
            StandardExternalCollection = _db.GetCollection<StandardExternal>(StandardExternalCollectionName);
            StandardInternalCollection = _db.GetCollection<StandardInternal>(StandardInternalCollectionName);
            StandardWireCollection = _db.GetCollection<StandardWire>(StandardWireCollectionName);
            UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        }
    }
}
