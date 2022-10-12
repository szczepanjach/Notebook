using Microsoft.EntityFrameworkCore.Storage;
using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextTransaction dbContextTransaction;

        public UnitOfWork(NotebookDbContext notebookDbContext)
        {
            dbContextTransaction = notebookDbContext.Database.BeginTransaction();
        }

        public async Task Complete(CancellationToken cancellationToken)
        {
            await dbContextTransaction.CommitAsync(cancellationToken);
        }
    }
}
