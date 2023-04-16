
namespace ThreadsLib.Models
{
    [BsonIgnoreExtraElements]
    public class MetricWire
    {
        [BsonId]
        public ObjectId MWId { get; set; }
        [BsonElement("Pitch")]
        public double Pitch { get; set; }
        [BsonElement("WireSize")]
        public double WireSize { get; set; }
        [BsonElement("Add")]
        public double Add { get; set; }
        [BsonElement("Constant")]
        public double Constant { get; set; }
    }
}
