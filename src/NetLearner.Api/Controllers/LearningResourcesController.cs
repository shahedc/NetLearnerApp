using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetLearner.Api.Infrastructure;
using NetLearner.SharedLib.Models;

namespace NetLearner.Api.Controllers
{
    // NOTE: order of precedence
    // 1. public JsonResult Get()
    // 2. [Produces("application/json")]
    // 3. Accept: application/json

    [Produces("application/xml")]
    // [Produces("application/json")] 
    [ApiController]
    [Route("api/[controller]")]
    public class LearningResourcesController : ControllerBase
    {
        private readonly ISampleRepository _sampleRepository;

        public LearningResourcesController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        // GET: api/LearningResources
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_sampleRepository.LearningResources());
        }

        // GET: api/LearningResources/search?fragment=Wa
        [HttpGet("Search")]
        public IActionResult Search(string fragment)
        {
            var result = _sampleRepository.GetByPartialName(fragment);
            if (!result.Any())
            {
                return NotFound(fragment);
            }
            return Ok(result);
        }

        // GET api/LearningResources/RL1
        [HttpGet("{listName}")]
        public LearningResource Get(string listName)
        {
            return _sampleRepository.GetByListName(listName);
        }
        // GET: api/LearningResources/queried?listName=RL1
        [HttpGet("Queried")]
        public LearningResource Queried(string listName)
        {
            return _sampleRepository.GetByListName(listName);
        }
    }
}
