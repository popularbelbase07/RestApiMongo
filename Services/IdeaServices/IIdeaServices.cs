using InnovationAPI.DTO;
using InnovationAPI.Models;

namespace InnovationAPI.Services
{
    public interface IIdeaServices
    {
        Task<IEnumerable<Idea>> GetCollections();

        Task<Idea> GetCollections(string id);

        Task<Idea>  CreateCollections(Idea idea);

        Task<Idea>  UpdateCollection(string id, Idea idea);

        Task DeleteCollection(string id);

        public Task<IdeasByMuId> GetIdeaByIdeatorMuId(string MuId);

        public Task<List<IdeaDTO>> FetchAndMapsIdeas();

        Task<IEnumerable<FeedbackIdListDTO>> GetCollectionsObjectList();
    }
}
