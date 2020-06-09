using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class LearningResource
    {
        public int Id { get; set; }

        [DisplayName("Resource")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [DisplayName("URL")]
        [Required]
        [StringLength(255)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public int ResourceListId { get; set; }
        [DisplayName("In List")]
        public ResourceList ResourceList { get; set; }

        [DisplayName("Feed Url")]
        [StringLength(255)]
        public string ContentFeedUrl { get; set; }

        public List<LearningResourceTopicTag> LearningResourceTopicTags { get; set; }
    }
}
