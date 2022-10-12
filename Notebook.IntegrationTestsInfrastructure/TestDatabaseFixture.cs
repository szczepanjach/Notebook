using Microsoft.EntityFrameworkCore;
using Notebook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.IntegrationTestsInfrastructure
{
    public class TestDatabaseFixture
    {
        private const string CONNECTION_STRING =
            "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=notebookIntegrationTest;";
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    _databaseInitialized = true;
                }
            }
        }

        public NotebookDbContext CreateContext()
            => new NotebookDbContext(
                new DbContextOptionsBuilder<NotebookDbContext>()
                .UseSqlServer(CONNECTION_STRING)
                .Options);
    }
}
