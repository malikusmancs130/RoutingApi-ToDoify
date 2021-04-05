using FluentAssertions;
using NUnit.Framework;
using System;

namespace RoutingApi.Domain.UnitTests.ValueObjects
{
    public class TodoTests
    {
        [Test]
        public void ShouldHaveValidObject()
        {
            var timeStamp = DateTime.Now;
            var dbModel = new Domain.Entities.Todo
            {
                CreationTime = timeStamp,
                DueDate = timeStamp.AddDays(30),
                Id = 1,
                IsCompleted = false,
                IsDeleted = false,
                TaskName = "Test"
            };
            dbModel.Should().NotBeNull();
            dbModel.Id.Should().Be(1);
            dbModel.CreationTime.Should().Be(timeStamp);
            dbModel.DueDate.Should().NotBe(timeStamp);
        }
    }
}
