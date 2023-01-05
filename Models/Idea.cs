using InnovationAPI.DTO;
using MongoDB.Bson;
namespace InnovationAPI.Models
{
    public class Idea:IdeaDTO
    {
        public Ideator Ideator { get; set; }
        public Segment Segements { get; set; }  
        public List<FeedBack>? Feedbacks { get; set; }    
        public Portfolio Portfolio { get; set; }


        public Idea()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }

    }
}
