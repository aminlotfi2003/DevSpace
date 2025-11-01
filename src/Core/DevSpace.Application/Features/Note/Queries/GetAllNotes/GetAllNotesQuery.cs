using DevSpace.Application.Common.Models.Results;
using Mediator;

namespace DevSpace.Application.Features.Note.Queries.GetAllNotes;

public record GetAllNotesQuery : IRequest<OperationResult<List<GetAllNotesResult>>>;
