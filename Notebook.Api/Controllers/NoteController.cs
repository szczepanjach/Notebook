using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notebook.Api.Contract;
using Notebook.Application.ArchiveNote;
using Notebook.Application.CreateNote;
using Notebook.Application.DeleteNote;
using Notebook.Application.GetNoteById;
using Notebook.Application.GetNotesList;
using Notebook.Application.IsSubjectInUse;
using Notebook.Application.UpdateNote;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Notebook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController: ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public NoteController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllNotes(CancellationToken cancellationToken)
        {
            var getAllNotesQuery = new GetAllNotesQuery();
            var allNotes = await mediator.Send(getAllNotesQuery);
            return Ok(allNotes);
        }

        [HttpGet("getbyid/{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var getNoteByIdQuery = new GetNoteByIdQuery(id);
            var note = await mediator.Send(getNoteByIdQuery);
            return Ok(note);
        }

        [HttpGet("issubjectinuse/{noteId:int}/{subject}")]
        public async Task<IActionResult> IsSubjectInUse(int noteId, string subject, CancellationToken cancellationToken)
        {
            var isSubjectInUseQuery = new IsSubjectInUseQuery(subject,noteId);
            var isSubjectInUse = await mediator.Send(isSubjectInUseQuery);
            return Ok(isSubjectInUse);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest createNoteRequest, CancellationToken cancellationToken)
        {
            if (createNoteRequest == null)
            {
                return BadRequest("Incorrect request");
            }
            var command = mapper.Map<CreateNoteCommand>(createNoteRequest);
            var id = await mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteRequest updateNoteRequest, CancellationToken cancellationToken)
        {
            if (updateNoteRequest == null)
            {
                return BadRequest("Incorrect request");
            }
            var command = mapper.Map<UpdateNoteCommand>(updateNoteRequest);
            var id = await mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpPost("archivenote")]
        public async Task<IActionResult> ArchiveNote([FromBody] ArchiveNoteRequest archiveNoteRequest, CancellationToken cancellationToken)
        {
            var archiveNoteCommand = mapper.Map<ArchiveNoteCommand>(archiveNoteRequest);
            await mediator.Send(archiveNoteCommand, cancellationToken);
            return Ok();
        }

        [HttpDelete("deletenote/{id:int}")]
        public async Task<IActionResult> DeleteNote(int id, CancellationToken cancellationToken)
        {
            var deleteNoteCommand = new DeleteNoteCommand()
            {
                NoteId = id
            };
            await mediator.Send(deleteNoteCommand, cancellationToken);
            return Ok();
        }
    }
}
