using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class LearningResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; }
    }
}
