using InnovationAPI.Models;

namespace InnovationAPI.Services
{
    public interface IIdeaServices
    {
        Task<IEnumerable<Idea>> GetCollections();
    }
}
