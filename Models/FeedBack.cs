using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace InnovationAPI.Models
{
    public class FeedBack
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeedbackId { get; set; }

        [BsonElement("feedbackName")]
        public string? Value { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }

        public Segment Segements { get; set; }

        public FeedBack()
        {
            FeedbackId = ObjectId.GenerateNewId().ToString();
        }
    }
}
