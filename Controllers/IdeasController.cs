using InnovationAPI.DTO;
using InnovationAPI.Models;
using InnovationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnovationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private readonly IIdeaServices _ideaServices;

        public IdeasController(IIdeaServices _ideas)
        {
            this._ideaServices = _ideas; 
        }

        
        [HttpGet("GetAll")]
        public async Task<ActionResult<Idea>> GetAll()
        {
            var Ideas = await _ideaServices.GetCollections();
                return Ok(Ideas);   
        }

        [HttpGet]
        public async Task<ActionResult<FeedbackIdListDTO>> Get()
        {
            var ideas = await _ideaServices.GetCollectionsObjectList();
            return Ok(ideas);
        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Idea>> Get(string id)
        {
            var ExistingIdeas = await _ideaServices.GetCollections(id);

            if (ExistingIdeas == null)
            {
                return NotFound($"Idea with id = {id} not found !!");
            }
            return Ok(ExistingIdeas);

        }
        */


        [HttpPost]

        public async Task<ActionResult<Idea>> Post([FromBody] Idea idea)
        {
            if (idea == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ideaServices.CreateCollections(idea);

            return CreatedAtAction(nameof(Get), new {id = idea.IdeaId}, idea);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Idea>> Put( string id, [FromBody] Idea idea)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingIdea = await _ideaServices.GetCollections(id);

            if (existingIdea == null )
            {
                return NotFound($"Idea with Id = {id} not found!!");
            }
            await _ideaServices.UpdateCollection(id, idea);
            //return Ok(existingIdea);
            return Ok($"Idea with Id = {id} is updated !!");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var idea = await _ideaServices.GetCollections(id);

            if (idea == null )
            {
                return NotFound($"Idea with Id = {id} not found!!");
            }
            _ideaServices.DeleteCollection(id);

            return Ok($"Idea with Id = {id} is Deleted !!");

            }

        [HttpGet("{MuId}")]
        public async Task<ActionResult<Idea>> GetByMuid(string MuId)
        {
            var ExistingIdeas = await _ideaServices.GetIdeaByIdeatorMuId(MuId);
            if (ExistingIdeas == null)
            {
                return NotFound($"Idea with id = {MuId} not found !!");
            }
            return Ok(ExistingIdeas);
        }

        [HttpGet ("DisplayOnlyIdeas")]
        public async Task<ActionResult<Idea>> GetMapped()
        {
            var ideas =   await _ideaServices.FetchAndMapsIdeas();  
            return Ok(ideas);
        }

    }
}
