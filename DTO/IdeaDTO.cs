using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace InnovationAPI.DTO
{
    public class IdeaDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdeaId { get; set; }

        [BsonElement("ideaName")]
        [Required(ErrorMessage = "Idea name is required")]
        public string IdeaName { get; set; }

        [BsonElement("description")]
        [StringLength(512, MinimumLength = 80, ErrorMessage = "This fied must be morethan 80 characters")]
        [Required(ErrorMessage = "Idea name is required")]
        public string Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }

        public IdeaDTO()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }
    }
}
