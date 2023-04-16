
namespace ThreadsLib.Models
{
    public class UserModel
    {
        [BsonId]
        public ObjectId UserId { get; set; }
        [BsonElement("ObjectIdentifier")]
        public string ObjectIdentifier { get; set; }
        [BsonElement("GivenName")]
        public string GivenName { get; set; }
        [BsonElement("FamilyName")]
        public string FamilyName { get; set; }
        [BsonElement("DisplayName")]
        public string DisplayName { get; set; }
        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }
    }
}
