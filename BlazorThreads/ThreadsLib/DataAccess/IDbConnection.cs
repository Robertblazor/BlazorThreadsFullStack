namespace ThreadsLib.DataAccess
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<MetricExternal> MetricExternalCollection { get; }
        string MetricExternalCollectionName { get; }
        IMongoCollection<MetricInternal> MetricInternalCollection { get; }
        string MetricInternalCollectionName { get; }
        IMongoCollection<MetricWire> MetricWireCollection { get; }
        string MetricWireCollectionName { get; }
        IMongoCollection<StandardExternal> StandardExternalCollection { get; }
        string StandardExternalCollectionName { get; }
        IMongoCollection<StandardInternal> StandardInternalCollection { get; }
        string StandardInternalCollectionName { get; }
        IMongoCollection<StandardWire> StandardWireCollection { get; }
        string StandardWireCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
        string UserCollectionName { get; }
    }
}