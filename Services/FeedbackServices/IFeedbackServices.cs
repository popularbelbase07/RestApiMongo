using InnovationAPI.Models;

namespace InnovationAPI.Services.FeedbackServices
{
    public interface IFeedbackServices
    {
        Task<IEnumerable<FeedBack>> GetFeedbacks();

        Task<FeedBack> GetFeedbacks(string id);

        Task<FeedBack> CreateFeedbacks(FeedBack feedback);

        Task<FeedBack> UpdateFeedbacks(string id, FeedBack feedBack);

        Task DeleteFeedbacks(string id);

        //public Task<FeedBack>GetFeedBacksByIdeaId(string id);
    }
}
