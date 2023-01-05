using InnovationAPI.Models;

namespace InnovationAPI.DTO
{
    public class FeedbackIdListDTO : IdeaDTO
    {
      
        public Ideator Ideator { get; set; }

        public Segment Segements { get; set; }

        public List<string> FeedbackIds { get; set; }

        public string PortfolioName { get; set; }

    }
}
