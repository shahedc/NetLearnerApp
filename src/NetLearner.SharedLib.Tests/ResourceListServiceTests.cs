using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NetLearner.SharedLib.Tests
{
    public class ResourceListServiceTests
    {
        [Trait("Resource List Tests", "Adding RL")]
        [Theory(DisplayName = "Add New Resource List")]
        [InlineData("RL1")]
        public async void TestAdd(string expectedName)
        {
            var options = new DbContextOptionsBuilder<LibDbContext>()
                .UseInMemoryDatabase(databaseName: "TestNewListDb").Options;

            // Set up a context (connection to the "DB") for writing
            using (var context = new LibDbContext(options))
            {
                // 1. Arrange
                var rl = new ResourceList
                {
                    Name = "RL1"
                };

                // 2. Act 
                var rls = new ResourceListService(context);
                await rls.Add(rl);
            }

            using (var context = new LibDbContext(options))
            {
                var rls = new ResourceListService(context);
                var result = await rls.Get();

                // 3. Assert
                Assert.NotEmpty(result);
                Assert.Single(result);
                Assert.NotEmpty(result.First().Name);
                Assert.Equal(expectedName, result.First().Name);
            }
        }
    }
}
