using Dapper;
using MediatR;
using Notebook.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.GetNotesList
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, IEnumerable<NoteDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllNotesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<NoteDto>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"select n.Id, n.Subject, n.LastUpdateDate, n.IsArchived
                                from Notes n";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return await connection.QueryAsync<NoteDto>(sql);
        }
    }
}
