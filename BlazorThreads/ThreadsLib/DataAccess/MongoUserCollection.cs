
namespace ThreadsLib.DataAccess
{

    public class MongoUserCollection : IUserCollection
    {
        private readonly IMongoCollection<UserModel> _users;
        public MongoUserCollection(IDbConnection db)
        {
            _users = db.UserCollection;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }
        public async Task<UserModel> GetUserByMongoAsync(ObjectId Id)
        {
            var result = await _users.FindAsync(u => u.UserId == Id);
            return result.FirstOrDefault();
        }
        public async Task<UserModel> GetUserByAzureAsync(string Identifier)
        {
            var result = await _users.FindAsync(u => u.ObjectIdentifier == Identifier);
            return result.FirstOrDefault();
        }
        public Task CreateUser(UserModel user)
        {
            return _users.InsertOneAsync(user);
        }
        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("userId", user.UserId);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}
