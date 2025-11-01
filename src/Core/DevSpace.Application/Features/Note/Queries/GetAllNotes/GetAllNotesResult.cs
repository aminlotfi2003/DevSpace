using AutoMapper;
using DevSpace.Application.Common.Profiles;

namespace DevSpace.Application.Features.Note.Queries.GetAllNotes;

public record GetAllNotesResult(int NoteId, string Title, int NoteOwnerId, string NoteOwnerUserName)
    : ICreateMapper<Domain.Entities.Note>
{
    public void Map(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Note, GetAllNotesResult>()
            .ForCtorParam(nameof(NoteId), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(NoteOwnerId), opt => opt.MapFrom(src => src.OwnerId))
            .ForCtorParam(nameof(NoteOwnerUserName), opt => opt.MapFrom(src => src.User.UserName))
            .ReverseMap();
    }
}
