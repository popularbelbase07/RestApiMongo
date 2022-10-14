using InnovationAPI.Models;

namespace InnovationAPI.DTO
{
    public class IdeasByMuId
    {
        public string MuId { get; set; }
        public List<Idea> Ideas { get; set; }
    }
}
