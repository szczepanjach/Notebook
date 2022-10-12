using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notebook.Application.Infrastructure;
using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using Notebook.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Infrastructure
{
    public class InfrastructureRegistrator
    {
        public static void RegisterInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotebookDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        }
    }
}
