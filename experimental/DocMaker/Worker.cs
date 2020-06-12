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
                "https://wakeupandcode.com/authentication-authorization-in-asp-net-core-razor-pages",
                "https://wakeupandcode.com/blazor-full-stack-web-dev-in-asp-net-core",
                "https://wakeupandcode.com/cookies-and-consent-in-asp-net-core",
                "https://wakeupandcode.com/deploying-asp-net-core-to-azure-app-service",
                "https://wakeupandcode.com/ef-core-relationships-in-asp-net-core",
                "https://wakeupandcode.com/forms-and-fields-in-asp-net-core",

                "https://wakeupandcode.com/generic-host-builder-in-asp-net-core",
                "https://wakeupandcode.com/handling-errors-in-asp-net-core",
                "https://wakeupandcode.com/iis-hosting-for-asp-net-core-web-apps",
                "https://wakeupandcode.com/javascript-css-html-static-files-in-asp-net-core",
                "https://wakeupandcode.com/key-vault-for-asp-net-core-web-apps",
                "https://wakeupandcode.com/logging-in-asp-net-core",

                "https://wakeupandcode.com/middleware-in-asp-net-core",
                "https://wakeupandcode.com/net-core-3-vs2019-and-csharp-8",
                "https://wakeupandcode.com/organizational-accounts-for-asp-net-core",
                "https://wakeupandcode.com/production-tips-for-asp-net-core-web-apps",
                "https://wakeupandcode.com/query-tags-in-ef-core-for-asp-net-core",
                "https://wakeupandcode.com/razor-pages-in-asp-net-core",

                "https://wakeupandcode.com/summarizing-build-2019-signalr-service",
                "https://wakeupandcode.com/tag-helper-authoring-in-asp-net-core",
                "https://wakeupandcode.com/unit-testing-in-asp-net-core",
                "https://wakeupandcode.com/validation-in-asp-net-core",
                "https://wakeupandcode.com/worker-service-in-asp-net-core",
                "https://wakeupandcode.com/xml-json-serialization-in-asp-net-core",

                "https://wakeupandcode.com/yaml-defined-cicd-for-asp-net-core",
                "https://wakeupandcode.com/zero-downtime-web-apps-for-asp-net-core"
            };


            _logger.LogInformation($"Processing {articleUrls.Length} docs at: {DateTimeOffset.Now}");
            for (var articleCounter = 0; articleCounter < articleUrls.Length; articleCounter++)
            {
                _logger.LogInformation($"Making doc {articleCounter + 1} at: {DateTimeOffset.Now}");
                DocEngine.MakeDoc(articleUrls[articleCounter]);
            }
            _logger.LogInformation($"Completed {articleUrls.Length} docs at: {DateTimeOffset.Now}");

        }
    }
}
