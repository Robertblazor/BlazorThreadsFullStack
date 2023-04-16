namespace ThreadsLib.DataAccess
{
    public interface IStandardWireCollection
    {
        Task CreateStandardWireAsync(StandardWire standardWire);
        Task<List<StandardWire>> GetAllStandardWiresAsync();
        Task<StandardWire> GetStandardWiresByPitchAsync(double pitch);
    }
}