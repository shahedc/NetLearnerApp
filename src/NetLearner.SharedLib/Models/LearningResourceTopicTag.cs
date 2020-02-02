using System;
using System.Collections.Generic;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class LearningResourceTopicTag
    {
        public int LearningResourceId { get; set; }
        public LearningResource LearningResource { get; set; }

        public int TopicTagId { get; set; }
        public TopicTag TopicTag { get; set; }

    }
}
