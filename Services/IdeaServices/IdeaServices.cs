using InnovationAPI.DatabaseSettings;
using InnovationAPI.Models;
using MongoDB.Driver;

namespace InnovationAPI.Services.IdeaServices
{
    public class IdeaServices : IIdeaServices
    {
        private readonly IMongoCollection<Idea> _ideas;

        public IdeaServices(IDatabaseSettings settings ,IMongoClient mongoClient )
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ideas = database.GetCollection<Idea>("Ideas");

        }
        public async Task<IEnumerable<Idea>> GetCollections()
        {
            return await _ideas.Find(_ => true).ToListAsync();  
        }
    }
}
