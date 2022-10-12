using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Infrastructure
{
    public class DatabaseMigrator
    {
        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<NotebookDbContext>();
            dataContext.Database.Migrate();
        }
    }
}
