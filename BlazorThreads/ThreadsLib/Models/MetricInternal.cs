
namespace ThreadsLib.Models
{
    [BsonIgnoreExtraElements]
    public class MetricInternal
    {
        [BsonId]
        public ObjectId MIId { get; set; }
        [BsonElement("ID")]
        public int InternalId { get; set; }
        [BsonElement("ThreadDesignition")]
        public string ThreadDesignition { get; set; }
        [BsonElement("CustomThreadDesignition")]
        public string CustomThreadDesignition { get; set; }
        [BsonElement("Pitch")]
        public double Pitch { get; set; }
        [BsonElement("Class")]
        public string Classification { get; set; }
        [BsonElement("MinorDiaMin")]
        public double MinorDiaMin { get; set; }
        [BsonElement("MinorDiaMax")]
        public double MinorDiaMax { get; set; }
        [BsonElement("PitchDiaMin")]
        public double PitchDiaMin { get; set; }
        [BsonElement("PitchDiaMax")]
        public double PitchDiaMax { get; set; }
        [BsonElement("MajorDiaMin")]
        public double MajorDiaMin { get; set; }
        [BsonElement("MajorDiaMax")]
        public double MajorDiaMax { get; set; }
        [BsonElement("TapDrillBasic")]
        public double TapDrillBasic { get; set; }
        [BsonElement("ThreadDepthMin")]
        public double ThreadDepthMin { get; set; }
        [BsonElement("ThreadRunouts")]
        public double ThreadRunouts { get; set; }
    }
}
