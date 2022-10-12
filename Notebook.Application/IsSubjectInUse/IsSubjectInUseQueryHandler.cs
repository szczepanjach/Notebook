using Dapper;
using MediatR;
using Notebook.Application.GetNoteById;
using Notebook.Application.GetNotesList;
using Notebook.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.IsSubjectInUse
{
    public class IsSubjectInUseQueryHandler : IRequestHandler<IsSubjectInUseQuery, bool>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public IsSubjectInUseQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<bool> Handle(IsSubjectInUseQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"select top(1) 1 from Notes n where n.Subject = @subject and  n.Id <> @noteId";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            var result = await connection.QueryAsync<int>(sql, new { request.Subject, request.NoteId });
            return result.Any();
        }
    }
}
