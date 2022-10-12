using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Notebook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Notebook.IntegrationTestsInfrastructure
{
    [Collection("DatabaseIntegrationTests")]
    public class IntegrationTestsClassBase : IClassFixture<TestDatabaseFixture>, IDisposable
    {
        protected readonly TestDatabaseFixture testDatabaseFixture;
        protected readonly NotebookDbContext notebookDbContext;
        private readonly IDbContextTransaction dbContextTransaction;

        public IntegrationTestsClassBase(TestDatabaseFixture testDatabaseFixture)
        {
            this.testDatabaseFixture = testDatabaseFixture;
            this.notebookDbContext = testDatabaseFixture.CreateContext();
            this.dbContextTransaction = notebookDbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            dbContextTransaction.Rollback();
            notebookDbContext.Dispose();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.notebookDbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
