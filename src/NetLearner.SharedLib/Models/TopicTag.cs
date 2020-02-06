using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class TopicTag
    {
        public int Id { get; set; }

        [DisplayName("Tag")]
        public string TagValue { get; set; }

        public List<LearningResourceTopicTag> LearningResourceTopicTags { get; set; }
    }
}
