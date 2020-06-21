using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetLearner.Api.Infrastructure
{
    public class SampleRepository : ISampleRepository
    {

        public List<LearningResource> LearningResources()
        {
            var resourceLists = new List<ResourceList>();
            var resourceList = new ResourceList
            {
                Id = 1,
                Name = "RL1",
                LearningResources = new List<LearningResource>()
            };
            resourceLists.Add(resourceList);
            return new List<LearningResource>
            {
                new LearningResource
                {
                    Id = 1,
                    Name = "ASP .NET Core Docs",
                    Url = "https://docs.microsoft.com/aspnet/core",
                    ResourceListId = 1,
                    ResourceList = resourceList
                },
                new LearningResource
                {
                    Id = 2,
                    Name = "Wake Up And Code!",
                    Url = "https://WakeUpAndCode.com",
                    ResourceListId = 1,
                    ResourceList = resourceList,
                    ContentFeedUrl = "https://WakeUpAndCode.com/rss"
                },
            }
            .OrderBy(ci => ci.Name).ToList();
        }

        public List<LearningResource> GetByPartialName(string nameSubstring)
        {
            return LearningResources()
                .Where(lr => lr.Name
                    .IndexOf(nameSubstring, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                .ToList();

        }

        public LearningResource GetByListName(string listName)
        {
            return LearningResources().FirstOrDefault(lr => lr.ResourceList.Name == listName);
        }
    }
}
