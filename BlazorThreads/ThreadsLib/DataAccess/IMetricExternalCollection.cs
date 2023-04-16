namespace ThreadsLib.DataAccess
{
    public interface IMetricExternalCollection
    {
        Task CreateMetricExternalAsync(MetricExternal metricExternal);
        Task<List<MetricExternal>> GetAllMetricExternalsAsync();
        Task<MetricExternal> GetMetricExternalByInternalId(int id);
        Task<List<MetricExternal>> GetMetricExternalsByDesignition(string designition);
    }
}