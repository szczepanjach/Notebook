using Bogus;
using FluentAssertions;
using Notebook.Domain.DomainServices;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.Entities.NoteAggregate.Exceptions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Notebook.Domain.UnitTests.Entities
{
    public class NoteTests
    {
        [Fact]
        public void SetSubjectThrowWhenToShortValue()
        {
            // Arrange
            var sut = new Note();
            var shortSubject = new Faker().Random.String2(3);
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);

            // Act
            Action action = () => sut.SetSubject(shortSubject, isSubjectUsedServiceSubstitute);

            // Assert
            action.Should().Throw<IncorrectSubjectException>();
        }

        [Fact]
        public void SetSubjectThrowWhenToLongValue()
        {
            // Arrange
            var sut = new Note();
            var longSubject = new Faker().Random.String2(51);
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);

            // Act
            Action action = () => sut.SetSubject(longSubject, isSubjectUsedServiceSubstitute);

            // Assert
            action.Should().Throw<IncorrectSubjectException>();
        }

        [Fact]
        public void SetSubjectIsAbleToSetCorrectLenghtValue()
        {
            // Arrange
            var sut = new Note();
            var correctSubjectValue = new Faker().Random.String2(50);
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);

            // Act
            sut.SetSubject(correctSubjectValue, isSubjectUsedServiceSubstitute);

            // Assert
            sut.Subject.Should().Be(correctSubjectValue);
        }

        [Fact]
        public void SetBodyIsAbleToSetCorrectLenghtValue()
        {
            // Arrange
            var sut = new Note();
            var correctBodyValue = new Faker().Random.String2(2000);

            // Act
            sut.SetBody(correctBodyValue);

            // Assert
            sut.Body.Should().Be(correctBodyValue);
        }

        [Fact]
        public void SetBodyThrowWhenToLongValue()
        {
            // Arrange
            var sut = new Note();
            var longBodyValue = new Faker().Random.String2(2001);

            // Act
            Action action = () => sut.SetBody(longBodyValue);

            // Assert
            action.Should().Throw<IncorrectBodyException>();
        }

        [Fact]
        public void AddTagCanNotAddMoreThan10Tags()
        {
            // Arrange
            var sut = new Note();
            for(int i = 0; i< 10; i++)
            {
                sut.AddTag("tag" + i);
            }

            // Act
            Action action = () => sut.AddTag("test");

            // Assert
            action.Should().Throw<UnableToAddMoreThan10TagsException>();
        }

        [Fact]
        public void AddTagCanNotAddDuplicatedTag()
        {
            // Arrange
            var sut = new Note();
            var tagValue = "test";
            sut.AddTag(tagValue);

            // Act
            Action action = () => sut.AddTag(tagValue);

            // Assert
            action.Should().Throw<TagsDuplicatedException>();
        }

        [Fact]
        public void AddTagIsAbleToAddCorrectTag()
        {
            // Arrange
            var sut = new Note();
            var tagValue = "test";
            sut.AddTag(tagValue);

            // Act
            sut.AddTag("test2");

            // Assert
            sut.Tags.Should().HaveCount(2);
            sut.Tags.Any(a => a.TagValue == "test2").Should().BeTrue();
        }

        [Fact]
        public void SetSubjectThrowWhenNoteArchived()
        {
            // Arrange
            var sut = new Note();
            sut.Archive();
            var subject = new Faker().Random.String2(10);
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);

            // Act
            Action action = () => sut.SetSubject(subject, isSubjectUsedServiceSubstitute);

            // Assert
            action.Should().Throw<ArchivedNoteEditonException>();
        }

        [Fact]
        public void SetBodyThrowWhenNoteArchived()
        {
            // Arrange
            var sut = new Note();
            sut.Archive();
            var bodyValue = new Faker().Random.String2(300);

            // Act
            Action action = () => sut.SetBody(bodyValue);

            // Assert
            action.Should().Throw<ArchivedNoteEditonException>();
        }

        [Fact]
        public void AddTagThrowWhenNoteArchived()
        {
            // Arrange
            var sut = new Note();
            sut.Archive();

            // Act
            Action action = () => sut.AddTag("test");

            // Assert
            action.Should().Throw<ArchivedNoteEditonException>();
        }

        [Fact]
        public void RemoveTagThrowWhenNoteArchived()
        {
            // Arrange
            var tag = "test";
            var sut = new Note();
            sut.AddTag(tag);
            sut.Archive();

            // Act
            Action action = () => sut.RemoveTag(tag);

            // Assert
            action.Should().Throw<ArchivedNoteEditonException>();
        }
    }
}
