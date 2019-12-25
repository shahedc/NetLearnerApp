using System;
using System.Collections.Generic;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class ResourceList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<LearningResource> LearningResources { get; set; }
    }
}
