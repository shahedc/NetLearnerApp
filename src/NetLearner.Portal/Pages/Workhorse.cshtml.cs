using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NetLearner.Portal.Utils;

namespace NetLearner.Portal.Pages
{
    public class WorkhorseModel : PageModel
    {
        private readonly ILogger _logger;

        public WorkhorseModel(ILogger<WorkhorseModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            PerformStep(1);
            PerformStep(2);
            PerformStep(3);

        }

        private void PerformStep(int stepId)
        {
            // Step 1: kick off something here
            _logger.LogInformation(LoggingEvents.Step1KickedOff, "Step {stepId} Kicked Off.", stepId);

            // Step 1: continue processing here
            _logger.LogInformation(LoggingEvents.Step1InProcess, "Step {stepId} in process...", stepId);

            // Step 1: wrap it up
            _logger.LogInformation(LoggingEvents.Step1Completed, "Step {stepId} completed!", stepId);

            try
            {
                // try something here
                throw new Exception();
            }
            catch (Exception someException)
            {
                _logger.LogError(LoggingEvents.SomeErrorOccurred, someException, "Trying step {stepId}", stepId);
                // continue handling exception
            }
        }
    }
}