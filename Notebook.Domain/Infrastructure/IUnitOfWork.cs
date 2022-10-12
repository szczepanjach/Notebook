using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        Task Complete(CancellationToken cancellationToken);
    }
}
