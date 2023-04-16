namespace ThreadsLib.DataAccess
{
    public interface IStandardInternalCollection
    {
        Task CreateStandardInternalAsync(StandardInternal standardInternal);
        Task<List<StandardInternal>> GetAllStandardInternalsAsync();
        Task<StandardInternal> GetStandardInternalByInternalId(int id);
        Task<List<StandardInternal>> GetStandardInternalsByDesignition(string designition);
    }
}