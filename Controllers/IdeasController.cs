using InnovationAPI.Models;
using InnovationAPI.Services;
using InnovationAPI.Services.IdeaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;

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

        [HttpGet]
        public async Task<ActionResult<Idea>> Get()
        {
            var Ideas = await _ideaServices.GetCollections();
                return Ok(Ideas);   
        }


    }
}
