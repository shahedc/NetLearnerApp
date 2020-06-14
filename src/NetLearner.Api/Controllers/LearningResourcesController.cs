using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetLearner.SharedLib.Models;

namespace NetLearner.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LearningResourcesController : ControllerBase
    {
        private readonly ILogger<LearningResourcesController> _logger;

        public LearningResourcesController(ILogger<LearningResourcesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            // sample list of learning resources
            return new string[] 
            {
                "ASP .NET Core 101", 
                "ASP .NET Core Advanced"
            };
        }
    }
}
