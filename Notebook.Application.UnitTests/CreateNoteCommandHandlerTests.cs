using Bogus;
using Notebook.Application.CreateNote;
using Notebook.Domain.DomainServices;
using Notebook.Domain.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notebook.Application.UnitTests
{
    public class CreateNoteCommandHandlerTests
    {
        [Fact]
        public async Task HandleShouldNotCallRepositoryIfSubjectIsDuplicated()
        {
            // Arrange
            var faker = new Faker();
            var subject = faker.Random.String2(10);
            var noteRepositorySubstitue = Substitute.For<INoteRepository>();
            noteRepositorySubstitue.ExistsWithSubject(Arg.Is<string>(s=>s == subject), Arg.Any<int>()).Returns(true);
            var isSubjectUsedService = new IsSubjectUsedService(noteRepositorySubstitue);
            var unitOfWork = new UnitOfWorkForTests();
            var sut = new CreateNoteCommandHandler(unitOfWork, isSubjectUsedService, noteRepositorySubstitue);
            var request = new CreateNoteCommand()
            {
                Body = faker.Random.String2(400),
                Subject = subject
            };
            noteRepositorySubstitue.ClearReceivedCalls();

            // Act
            await sut.Handle(request, CancellationToken.None);

            // Assert
            await noteRepositorySubstitue.DidNotReceiveWithAnyArgs().Create(default, CancellationToken.None);
        }
    }
}
