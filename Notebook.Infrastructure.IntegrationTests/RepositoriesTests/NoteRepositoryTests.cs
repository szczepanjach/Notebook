using Bogus;
using FluentAssertions;
using Notebook.Domain.DomainServices;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Infrastructure.Repositories;
using Notebook.IntegrationTestsInfrastructure;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notebook.Infrastructure.IntegrationTests.RepositoriesTests
{
    public class NoteRepositoryTests : IntegrationTestsClassBase
    {
        private readonly NoteRepository sut;
        public NoteRepositoryTests(TestDatabaseFixture testDatabaseFixture) 
            : base(testDatabaseFixture)
        {
            sut = new NoteRepository(notebookDbContext);
        }

        [Fact]
        public async Task CreateIsAbleToCreateRecord()
        {
            // Arrange
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);
            var faker = new Faker();
            var subject = faker.Random.String2(10);
            var body = faker.Random.String2(1000);
            var sampleTag = faker.Random.String2(10);
            var note = new Note();
            note.SetSubject(subject, isSubjectUsedServiceSubstitute);
            note.SetBody(body);
            note.AddTag(sampleTag);

            // Act
            await sut.Create(note, CancellationToken.None);

            // Assert
            DetachAllEntities();
            var noteFromDb = notebookDbContext.Notes.First();
            noteFromDb.Subject.Should().Be(subject);
            noteFromDb.Body.Should().Be(body);
            noteFromDb.Tags.Should().HaveCount(1);
            noteFromDb.Tags.Single().TagValue.Should().Be(sampleTag);
        }

        [Fact]
        public async Task DeleteIsAbleToDeleteRecord()
        {
            // Arrange
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);
            var faker = new Faker();
            var subject = faker.Random.String2(10);
            var body = faker.Random.String2(1000);
            var sampleTag = faker.Random.String2(10);
            var note = new Note();
            note.SetSubject(subject, isSubjectUsedServiceSubstitute);
            note.SetBody(body);
            note.AddTag(sampleTag);
            notebookDbContext.Notes.Add(note);
            notebookDbContext.SaveChanges();
            DetachAllEntities();

            // Act
            await sut.Delete(note.Id, CancellationToken.None);

            // Assert
            var notesFromDb = notebookDbContext.Notes.ToList();
            notesFromDb.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateIsAbleToUpdateRecord()
        {
            // Arrange
            var isSubjectUsedServiceSubstitute = Substitute.For<IIsSubjectUsedService>();
            isSubjectUsedServiceSubstitute.IsSubjectAlreadyUsed(default, default).ReturnsForAnyArgs(false);
            var faker = new Faker();
            var subject = faker.Random.String2(10);
            var oldBody = faker.Random.String2(1000);
            var newBody = faker.Random.String2(1000);
            var sampleTag = faker.Random.String2(10);
            var tagToRemove = faker.Random.String2(10);
            var tagToAdd = faker.Random.String2(10);
            var note = new Note();
            note.SetSubject(subject, isSubjectUsedServiceSubstitute);
            note.SetBody(oldBody);
            note.AddTag(sampleTag);
            note.AddTag(tagToRemove);
            notebookDbContext.Notes.Add(note);
            notebookDbContext.SaveChanges();
            DetachAllEntities();

            // Act
            var noteToUpdate = await sut.GetById(note.Id, CancellationToken.None);
            noteToUpdate.SetBody(newBody);
            noteToUpdate.RemoveTag(tagToRemove);
            noteToUpdate.AddTag(tagToAdd);
            await sut.Update(noteToUpdate, CancellationToken.None);

            // Assert
            var notesFromDb = notebookDbContext.Notes.ToList();
            notesFromDb.Should().HaveCount(1);
            var updatedNote = notesFromDb.Single();
            updatedNote.Body.Should().Be(newBody);
            updatedNote.Tags.Should().HaveCount(2);
            updatedNote.Tags.Any(a => a.TagValue.Equals(tagToAdd, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
            updatedNote.Tags.Any(a => a.TagValue.Equals(sampleTag, StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
        }
    }
}
