
namespace ThreadsLib.Models
{
    [BsonIgnoreExtraElements]
    public class StandardWire
    {
        [BsonId]
        public ObjectId SWId { get; set; }
        [BsonElement("TPI")]
        public double ThreadPerInch { get; set; }
        [BsonElement("WireSize")]
        public double WireSize { get; set; }
        [BsonElement("Add")]
        public double Add { get; set; }
        [BsonElement("Constant")]
        public double Constant { get; set; }
    }
}
