using AutoMapper;
using DevSpace.Application.Common.Contracts.Persistence;
using DevSpace.Application.Common.Models.Results;
using Mediator;

namespace DevSpace.Application.Features.Note.Queries.GetAllNotes;

internal class GetAllNotesQueryHandler(IUnitOfWork uow, IMapper mapper)
    : IRequestHandler<GetAllNotesQuery, OperationResult<List<GetAllNotesResult>>>
{
    public async ValueTask<OperationResult<List<GetAllNotesResult>>> Handle(GetAllNotesQuery req, CancellationToken ct)
    {
        var records = await uow.NoteRepository.GetAllNotesWithRelatedUserAsync(ct);

        var result = records.Select(mapper.Map<Domain.Entities.Note, GetAllNotesResult>).ToList();

        return OperationResult<List<GetAllNotesResult>>.SuccessResult(result);
    }
}
