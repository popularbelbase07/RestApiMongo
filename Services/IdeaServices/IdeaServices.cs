using InnovationAPI.DatabaseSettings;
using InnovationAPI.DTO;
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

        public async Task<IdeasByMuId> GetIdeaByIdeatorMuId(string MuId)
        {
            var foundMuid = await _ideas.Find(_ => _.Ideator.MuId == MuId).FirstOrDefaultAsync();

            List<Idea> AllIdeas = new List<Idea>();

            IdeasByMuId ideasbyMuid = new IdeasByMuId();

            if (foundMuid is not null)
            {
                AllIdeas =  _ideas.Find(_ => _.Ideator.IdeatorId == foundMuid.Ideator.IdeatorId).ToList();

                return new IdeasByMuId()
                {
                    Ideas = AllIdeas,
                    MuId = foundMuid.Ideator.MuId
                };


            }
            return ideasbyMuid;
        }

        // Display only List of ideas
        public async Task<List<IdeaDTO>> FetchAndMapsIdeas()
        {
            var ideas = await _ideas.Find(_ => true).ToListAsync();

            var mapProperties = ideas.Select(_ => new IdeaDTO()
            {
                IdeaId = _.IdeaId,
                IdeaName = _.IdeaName,
                Description = _.Description,
                CreatedAt = _.CreatedAt,
                UpdatedAt = _.UpdatedAt
            }).ToList();

            return mapProperties;
        }

        public async Task<IEnumerable<FeedbackIdListDTO>> GetCollectionsObjectList()
        {
            var IdeaCollections = await _ideas.Find(_ => true).ToListAsync();

            var myIdeas = IdeaCollections.Select(_ => new FeedbackIdListDTO()
            {
                IdeaId = _.IdeaId,
                IdeaName = _.IdeaName,
                Description = _.Description,
                CreatedAt = _.CreatedAt,
                UpdatedAt = _.UpdatedAt,
                Ideator = _.Ideator,
                Segements = _.Segements,
                FeedbackIds = _.Feedbacks.Select(x => x.FeedbackId).ToList(),
                PortfolioName = _.Portfolio?.PortfolioName

            });
            return myIdeas; 
        }
    }
}
