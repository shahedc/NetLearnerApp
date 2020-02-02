using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class ContentFeed
    {
        public int Id { get; set; }

        [DisplayName("Feed URL")]
        public string FeedUrl { get; set; }

        public int LearningResourceId { get; set; }
        public LearningResource LearningResource { get; set; }
    }
}
