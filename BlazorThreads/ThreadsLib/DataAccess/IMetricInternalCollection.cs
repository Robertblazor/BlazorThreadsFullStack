namespace ThreadsLib.DataAccess
{
    public interface IMetricInternalCollection
    {
        Task CreateMetricInternalAsync(MetricInternal metricInternal);
        Task<List<MetricInternal>> GetAllMetricInternalsAsync();
        Task<MetricInternal> GetMetricInternalByInternalId(int id);
        Task<List<MetricInternal>> GetMetricInternalsByDesignitionAsync(string designition);
    }
}