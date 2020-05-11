using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperAuthoring.Models
{
    public class SuperheroModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SuperName { get; set; }
        public bool HasSurvived { get; set; }

        public bool ShowInfoWithSpoilers { get; set; }
    }
}
