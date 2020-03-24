using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace NetLearner.Portal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // uses Generic Host in .NET Core 3.x
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((ctx, builder) =>
                //{
                //    var keyVaultEndpoint = GetKeyVaultEndpoint();
                //    if (!string.IsNullOrEmpty(keyVaultEndpoint))
                //    {
                //        var azureServiceTokenProvider = new AzureServiceTokenProvider();
                //        var keyVaultClient = new KeyVaultClient(
                //            new KeyVaultClient.AuthenticationCallback(
                //                azureServiceTokenProvider.KeyVaultTokenCallback));
                //        builder.AddAzureKeyVault(
                //            keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                //    }
                //}
            //)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                // clear default logging providers
                logging.ClearProviders();

                // add built-in providers manually, if desired 
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventLog();
                logging.AddEventSourceLogger();
            });


        private static string GetKeyVaultEndpoint() => "https://VAULT_NAME.vault.azure.net/";
    }
}
