using Bunit;
using NetLearner.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NetLearner.Blazor.Tests
{
    public class BlazorTest : TestContext
    {
        [Fact]
        public void TestCounter()
        {
            // Arrange
            var counterComponent = RenderComponent<Counter>();
            counterComponent.Find("p").MarkupMatches("<p>Current count: 0</p>");

            // Act
            var element = counterComponent.Find("button");
            element.Click();

            //Assert
            counterComponent.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}
