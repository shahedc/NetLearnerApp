using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NetLearner.Mvc.Controllers;
using Xunit;

namespace NetLearner.Mvc.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void  Index_ReturnsViewResultWithNoModel()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            // Act
            var result = controller.Index();

            // Assert correct non-null View returned with no Model
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(nameof(controller.Index), viewResult.ViewName);
            Assert.NotNull(viewResult.ViewData);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void Privacy_ReturnsViewResultWithNoModel()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            // Act
            var result = controller.Privacy();

            // Assert correct non-null View returned with no Model
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(nameof(controller.Privacy), viewResult.ViewName);
            Assert.NotNull(viewResult.ViewData);
            Assert.Null(viewResult.ViewData.Model);
        }

    }
}
