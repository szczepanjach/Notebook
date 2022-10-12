using Bogus;
using FluentAssertions;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.Entities.NoteAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static System.Collections.Specialized.BitVector32;

namespace Notebook.Domain.UnitTests.Entities
{
    public class TagTests
    {
        [Fact]
        public void SetTagThrowWhenToShortValue()
        {
            // Arrange
            var sut = new Tag();
            var shortTag = new Faker().Random.String2(1);

            // Act
            Action action = () => sut.SetTagValue(shortTag);

            // Assert
            action.Should().Throw<IncorrectTagLenghtException>();
        }

        [Fact]
        public void SetTagThrowWhenToLongValue()
        {
            // Arrange
            var sut = new Tag();
            var longTag = new Faker().Random.String2(21);

            // Act
            Action action = () => sut.SetTagValue(longTag);

            // Assert
            action.Should().Throw<IncorrectTagLenghtException>();
        }

        [Fact]
        public void SetTagIsAbleToSetCorrectLenghtValue()
        {
            // Arrange
            var sut = new Tag();
            var correctTagValue = new Faker().Random.String2(20);

            // Act
            sut.SetTagValue(correctTagValue);

            // Assert
            sut.TagValue.Should().Be(correctTagValue);
        }
    }
}
