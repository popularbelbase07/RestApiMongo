using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InnovationAPI.Models
{
    public class Idea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdeaId { get; set; }
        [BsonElement("ideaName")]
        [Required(ErrorMessage = "Idea name is required")]
        public string IdeaName { get; set; }

        [BsonElement("description")]
        [StringLength(512, MinimumLength = 80, ErrorMessage ="This fied must be morethan 80 characters")]
        [Required(ErrorMessage = "Idea name is required")]
        public string Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }


        public Idea()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }

    }
}
