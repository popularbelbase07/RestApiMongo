using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InnovationAPI.Models
{
    public class Portfolio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PortfolioId { get; set; }

        [BsonElement("portfolioName")]
        public string? PortfolioName { get; set; }

        [BsonElement("portfolioCode")]
        public string? PortfolioValue { get; set; }

        [BsonElement("value")]
        public int? Value { get; set; }

        public Portfolio()
        {
            PortfolioId = ObjectId.GenerateNewId().ToString();
        }


    }
}
