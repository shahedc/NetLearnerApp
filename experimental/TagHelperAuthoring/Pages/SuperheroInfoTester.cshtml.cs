using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelperAuthoring.Models;

namespace TagHelperAuthoring.Pages
{
    // WARNING: this class contains spoilers for Avengers Endgame (2019)
    public class SuperheroInfoTesterModel : PageModel
    {
        public SuperheroModel blackWidowInfo { get; set; }
        public SuperheroModel ironManInfo { get; set; }
        public SuperheroModel thorInfo { get; set; }

        public void OnGet()
        {
            blackWidowInfo = new SuperheroModel
            {
                LastName = "Romanoff",
                FirstName = "Natasha",
                SuperName = "Black Widow",
                HasSurvived = false,
                ShowInfoWithSpoilers = true
            };

            ironManInfo = new SuperheroModel
            {
                LastName = "Stark",
                FirstName = "Tony",
                SuperName = "Iron Man",
                HasSurvived = false,
                ShowInfoWithSpoilers = true
            };

            thorInfo = new SuperheroModel
            {
                LastName = "Odinson",
                FirstName = "Thor",
                SuperName = "Mighty Thor",
                HasSurvived = true,
                ShowInfoWithSpoilers = true
            };
        }
    }
}