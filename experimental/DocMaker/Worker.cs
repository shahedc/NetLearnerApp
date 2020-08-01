using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DocMaker.Utils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DocMaker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // string array of URLs *without* any trailing slash
            string[] articleUrls = {
                // prelude

                //"https://wakeupandcode.com/asp-net-core-code-sharing-between-blazor-mvc-and-razor-pages",
                //"https://wakeupandcode.com/hello-asp-net-core-v3-1",
                //"https://wakeupandcode.com/netlearner-on-asp-net-core-3-1",

                // A-Z chapters
                "https://wakeupandcode.com/authentication-authorization-in-asp-net-core-3-1",
                "https://wakeupandcode.com/blazor-full-stack-web-dev-in-asp-net-core-3-1",
                "https://wakeupandcode.com/cookies-and-consent-in-asp-net-core-3-1",
                "https://wakeupandcode.com/deploying-asp-net-core-3-1-to-azure-app-service",
                "https://wakeupandcode.com/ef-core-relationships-in-asp-net-core-3-1",
                "https://wakeupandcode.com/forms-and-fields-in-asp-net-core-3-1",

                "https://wakeupandcode.com/generic-host-builder-in-asp-net-core-3-1",
                "https://wakeupandcode.com/handling-errors-in-asp-net-core-3-1",
                "https://wakeupandcode.com/iis-hosting-for-asp-net-core-3-1-web-apps",
                "https://wakeupandcode.com/javascript-css-html-other-static-files-in-asp-net-core-3-1",
                "https://wakeupandcode.com/key-vault-for-asp-net-core-3-1-web-apps",
                "https://wakeupandcode.com/logging-in-asp-net-core-3-1",

                "https://wakeupandcode.com/middleware-in-asp-net-core-3-1",
                "https://wakeupandcode.com/net-5-0-vs2019-preview-and-c-9-0-for-asp-net-core-developers",
                "https://wakeupandcode.com/organizational-accounts-for-asp-net-core-3-1",
                "https://wakeupandcode.com/production-tips-for-asp-net-core-3-1-web-apps",
                "https://wakeupandcode.com/query-tags-in-ef-core-for-asp-net-core-3-1-web-apps",
                "https://wakeupandcode.com/razor-pages-in-asp-net-core-3-1",

                "https://wakeupandcode.com/signalr-in-asp-net-core-3-1",
                "https://wakeupandcode.com/tag-helper-authoring-in-asp-net-core-3-1",
                "https://wakeupandcode.com/unit-testing-in-asp-net-core-3-1",
                "https://wakeupandcode.com/validation-in-asp-net-core-3-1",
                "https://wakeupandcode.com/worker-service-in-net-core-3-1",
                "https://wakeupandcode.com/xml-+-json-output-for-web-apis-in-asp-net-core-3-1",

                "https://wakeupandcode.com/yaml-defined-ci-cd-for-asp-net-core-3-1",
                "https://wakeupandcode.com/zero-downtime-web-apps-for-asp-net-core-3-1"
            };


            _logger.LogInformation($"Processing {articleUrls.Length} docs at: {DateTimeOffset.Now}");
            for (var articleCounter = 0; articleCounter < articleUrls.Length; articleCounter++)
            {
                _logger.LogInformation($"Making doc {articleCounter + 1} at: {DateTimeOffset.Now}");
                try
                {
                    DocEngine.MakeDoc(articleUrls[articleCounter]);
                    _logger.LogInformation($"... URL processed.");
                } catch (Exception ex)
                {
                    _logger.LogError($"... URL not processed.");
                    _logger.LogError($"Error: {ex.Message}");
                }
            }
            _logger.LogInformation($"Completed {articleUrls.Length} docs at: {DateTimeOffset.Now}");

        }
    }
}
