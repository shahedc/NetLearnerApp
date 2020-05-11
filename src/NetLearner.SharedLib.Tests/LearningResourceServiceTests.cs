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
    public class LearningResourceServiceTests
    {
        [Trait("Learning Resource Tests", "Adding LR")]
        [Theory(DisplayName = "Add New Learning Resource")]
        [InlineData("LR1")]
        public async void TestAdd(string expectedName)
        {
            var options = new DbContextOptionsBuilder<LibDbContext>()
                .UseInMemoryDatabase(databaseName: "TestNewResourceDb").Options;

            // Set up a context (connection to the "DB") for writing
            using (var context = new LibDbContext(options))
            {
                // 1. Arrange
                var rl = new ResourceList
                {
                    Name = "RL1"
                };

                var lr = new LearningResource
                {
                    Name = "LR1",
                    Url = "https://somedomain.com",
                    ResourceList = rl
                };

                // 2. Act 
                var lrs = new LearningResourceService(context);
                await lrs.Add(lr);
            }

            using (var context = new LibDbContext(options))
            {
                var lrs = new LearningResourceService(context);
                var result = await lrs.Get();

                // 3. Assert
                Assert.NotEmpty(result);
                Assert.Single(result);
                Assert.NotEmpty(result.First().Name);
                Assert.Equal(expectedName, result.First().Name);
            }
        }
    }
}
