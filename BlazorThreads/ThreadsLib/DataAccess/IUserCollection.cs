namespace ThreadsLib.DataAccess
{
    public interface IUserCollection
    {
        Task CreateUser(UserModel user);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByAzureAsync(string Identifier);
        Task<UserModel> GetUserByMongoAsync(ObjectId Id);
        Task UpdateUser(UserModel user);
    }
}