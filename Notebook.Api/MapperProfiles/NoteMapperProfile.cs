using AutoMapper;
using Notebook.Api.Contract;
using Notebook.Application.ArchiveNote;
using Notebook.Application.CreateNote;
using Notebook.Application.UpdateNote;

namespace Notebook.Api.MapperProfiles
{
    public class NoteMapperProfile: Profile
    {
        public NoteMapperProfile()
        {
            CreateMap<CreateNoteRequest, CreateNoteCommand>();
            CreateMap<UpdateNoteRequest, UpdateNoteCommand>();
            CreateMap<ArchiveNoteRequest, ArchiveNoteCommand>();
        }
    }
}
