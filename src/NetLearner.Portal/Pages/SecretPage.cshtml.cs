using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace NetLearner.Portal
{
    public class SecretPageModel : PageModel
    {
        public IConfiguration _configuration { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }

        public SecretPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            Message1 = "My 1st key val = " + _configuration["MyKeyVaultSecret"];
            Message2 = "My 2nd key val = " + _configuration["AnotherVaultSecret"];
            Message3 = "My 3nd key val ? " + _configuration["NonExistentSecret"];
        }
    }
}