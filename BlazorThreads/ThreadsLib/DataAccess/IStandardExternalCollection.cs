namespace ThreadsLib.DataAccess
{
    public interface IStandardExternalCollection
    {
        Task CreateStandardExternalAsync(StandardExternal standardExternal);
        Task<List<StandardExternal>> GetAllStandardExternalsAsync();
        Task<StandardExternal> GetStandardExternalByInternalIdAsync(int id);
        Task<List<StandardExternal>> GetStandardExternalsByDesignitionAsync(string designition);
    }
}