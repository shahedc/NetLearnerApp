using System;
using System.Collections.Generic;
using System.Text;
using NetLearner.Pages.ResourceLists;
using System.Threading.Tasks;
using NetLearner.SharedLib.Services;
using Moq;
using NetLearner.SharedLib.Models;
using Xunit;
using System.Linq;

namespace NetLearner.Pages.Tests
{
    public class ResourceListPageTests
    {
        [Fact]
        public async Task OnGetAsync_LoadsResourceLists()
        {
            // Arrange
            var resourceLists = new List<ResourceList>();
            var resourceList = new ResourceList
            {
                Id = 1,
                Name = "RL1",
                LearningResources = new List<LearningResource>()
            };
            resourceLists.Add(resourceList);
            var mockService = new Mock<IResourceListService>();
            mockService.Setup(s => s.Get()).Returns(Task.FromResult(resourceLists));
            var pageModel = new IndexModel(mockService.Object);

            // Act
            await pageModel.OnGetAsync();

            // Assert
            var actualResourceList = Assert.IsAssignableFrom<IList<ResourceList>>(pageModel.ResourceLists);
            Assert.NotNull(actualResourceList);
            Assert.Single(actualResourceList);
            Assert.Equal(resourceList.Name, actualResourceList.First().Name);
        }
    }
}
