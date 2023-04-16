namespace ThreadsLib.DataAccess
{
    public interface IMetricWireCollection
    {
        Task CreateMetricWireAsync(MetricWire metricWire);
        Task<List<MetricWire>> GetAllMetricWiresAsync();
        Task<MetricWire> GetMetricWireAsync(double pitch);
    }
}