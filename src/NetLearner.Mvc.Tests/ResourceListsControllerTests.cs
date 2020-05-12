using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NetLearner.Mvc.Controllers;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetLearner.Mvc.Tests
{
    public class ResourceListsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResultWithModel()
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
            var controller = new ResourceListsController(mockService.Object);

            // Act
            var result = await controller.Index(); // as ViewResult;

            // Assert correct non-null View returned with expected Model

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(nameof(controller.Index), viewResult.ViewName);
            Assert.NotNull(viewResult.Model);
            Assert.Equal(typeof(List<ResourceList>), viewResult.Model.GetType());
        }

        [Fact]
        public async Task Delete_ReturnsViewResultWithModel()
        {

            // Arrange
            var resourceList = new ResourceList
            {
                Id = 1,
                Name = "RL1",
                LearningResources = new List<LearningResource>()
            };

            var mockService = new Mock<IResourceListService>();
            mockService.Setup(s => s.Get(resourceList.Id)).Returns(Task.FromResult(resourceList));
            var controller = new ResourceListsController(mockService.Object);

            // Act
            var result = await controller.Delete(resourceList.Id); // as ViewResult;

            // Assert correct non-null View returned with expected Model

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(nameof(controller.Delete), viewResult.ViewName);
            Assert.NotNull(viewResult.Model);
            Assert.Equal(typeof(ResourceList), viewResult.Model.GetType());
        }


    }
}
