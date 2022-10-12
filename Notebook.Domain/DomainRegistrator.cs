using Microsoft.Extensions.DependencyInjection;
using Notebook.Domain.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain
{
    public class DomainRegistrator
    {
        public static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddTransient<IIsSubjectUsedService, IsSubjectUsedService>();
        }
    }
}
