using InnovationAPI.Models;
using InnovationAPI.Services;
using InnovationAPI.Services.FeedbackServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {

        private readonly IFeedbackServices _feedbackServices;

        public FeedbacksController(IFeedbackServices feedbacks)
        {
            this._feedbackServices = feedbacks;
        }

        [HttpGet]
        public async Task<ActionResult<FeedBack>> Get()
        {
            var FeedBacks = await _feedbackServices.GetFeedbacks();
            return Ok(FeedBacks);
        }


        
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> Get(string id)
        {
            var ExistingFeedbacks = await _feedbackServices.GetFeedbacks(id);

            if (ExistingFeedbacks == null)
            {
                return NotFound($"Feedbacks with id = {id} not found !!");
            }
            return Ok(ExistingFeedbacks);

        }
        


        [HttpPost]

        public async Task<ActionResult<FeedBack>> Post([FromBody] FeedBack feedback)
        {
            if (feedback == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _feedbackServices.CreateFeedbacks(feedback);  

            return CreatedAtAction(nameof(Get), new { id = feedback.FeedbackId }, feedback);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FeedBack>> Put(string id, [FromBody] FeedBack feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingIdea = await _feedbackServices.GetFeedbacks(id);

            if (existingIdea == null)
            {
                return NotFound($"Feedback with Id = {id} not found!!");
            }
            await _feedbackServices.UpdateFeedbacks(id, feedback);
            //return Ok(existingIdea);
            return Ok($"Feedback with Id = {id} is updated !!");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var idea = await _feedbackServices.GetFeedbacks(id);

            if (idea == null)
            {
                return NotFound($"Feedback with Id = {id} not found!!");
            }
            _feedbackServices.DeleteFeedbacks(id);

            return Ok($"Feedback with Id = {id} is Deleted !!");

        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> Get(string id)
        {
            var ExistingFeedbacks = await _feedbackServices.GetFeedBacksByIdeaId(id);

            if (ExistingFeedbacks == null)
            {
                return NotFound($"Feedbacks with id = {id} not found !!");
            }
            return Ok(ExistingFeedbacks);

        }
        */

    }
}
