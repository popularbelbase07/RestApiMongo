using InnovationAPI.DatabaseSettings;
using InnovationAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        
       
        // Get all collection
        public async Task<IEnumerable<Idea>> GetCollections()
        {
            return await _ideas.Find(_ => true).ToListAsync();  
        }

        // Get all collection's specific object by id
        public async Task<Idea> GetCollections(string id)
        {
            var getbyid = await _ideas.Find(_ => _.IdeaId == id).FirstOrDefaultAsync();
            return getbyid;
        }

        // Post data to the collection
        public async Task<Idea> CreateCollections(Idea idea)
        {
            await _ideas.InsertOneAsync(idea);
            return idea;
        }

        // update special collection using Id
        public async Task<Idea> UpdateCollection(string id, Idea idea)
        {
            await _ideas.ReplaceOneAsync(_ => _.IdeaId == id, idea);
            return idea;

        }
        // update special collection using Id
        public async Task DeleteCollection(string id)
        {
          await _ideas.DeleteOneAsync(_ => _.IdeaId == id);
                       
          
        }


    }
}
