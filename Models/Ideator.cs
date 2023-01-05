using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace InnovationAPI.Models
{
    public class Ideator
    {
        //MongodbApp

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required(ErrorMessage ="Ideator Id is Required. You must be logged in")]
        public string IdeatorId { get; set; }

        [BsonElement("ideatorName")]
        [Required(ErrorMessage = "Ideator name is required")]
        public string IdeatorName { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }

        [BsonElement("muid")]
        public string MuId { get; set; }

        [BsonElement("officeAddress")]
        public string OfficeAddress { get; set; }



        public Ideator()
        {
            IdeatorId = ObjectId.GenerateNewId().ToString();
        }
    }
}
