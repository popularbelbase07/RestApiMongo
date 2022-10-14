using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InnovationAPI.Models
{
    public class Segment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SegmentId { get; set; }

        [BsonElement ("segementName")]
       public  List<string> SegmentName { get; set; }

        public Segment()
        {
            SegmentId = ObjectId.GenerateNewId().ToString();
        }
    }
}
