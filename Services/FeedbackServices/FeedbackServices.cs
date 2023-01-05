using InnovationAPI.DatabaseSettings;
using InnovationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace InnovationAPI.Services.FeedbackServices
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IMongoCollection<FeedBack> _feedbacks;
        private readonly IMongoCollection<Idea> _ideas;

        public FeedbackServices(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _feedbacks = database.GetCollection<FeedBack>("Feedbacks");
            _ideas = database.GetCollection<Idea>("Ideas");

        }

        public async Task<FeedBack> CreateFeedbacks(FeedBack feedback)
        {
            await _feedbacks.InsertOneAsync(feedback);
            return feedback;
        }

        public async Task DeleteFeedbacks(string id)
        {
            await _feedbacks.DeleteOneAsync(_ => _.FeedbackId == id);

        }

        public async Task<IEnumerable<FeedBack>> GetFeedbacks()
        {
            return await _feedbacks.Find(_ => true).ToListAsync();
        }

        public async Task<FeedBack> GetFeedbacks(string id)
        {
            var getbyid = await _feedbacks.Find(_ => _.FeedbackId == id).FirstOrDefaultAsync();
            return getbyid;
        }


        public async Task<FeedBack> UpdateFeedbacks(string id, FeedBack feedBack)
        {
            await _feedbacks.ReplaceOneAsync(_ => _.FeedbackId == id, feedBack);
            return feedBack;
        }


        /*

        public async Task<FeedBack> GetFeedBacksByIdeaId( string id)
        {
            var foundIdea = await _ideas.Find(_ => _.IdeaId == id).FirstOrDefaultAsync();

            return foundIdea.Feedbacks;
            
        }
        */
    }
}
