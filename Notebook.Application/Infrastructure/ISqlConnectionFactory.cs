using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Notebook.Application.Infrastructure
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
