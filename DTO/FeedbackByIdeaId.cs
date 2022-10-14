using InnovationAPI.Models;

namespace InnovationAPI.DTO
{
    public class FeedbackByIdeaId
    {
        public string IdeaId { get; set; }
        public List<FeedBack> Feedbacks{get; set;}
    }
}
