using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.UnitTests
{
    public class UnitOfWorkForTests : IUnitOfWork
    {

        public UnitOfWorkForTests()
        {
        }

        public Task Complete(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
