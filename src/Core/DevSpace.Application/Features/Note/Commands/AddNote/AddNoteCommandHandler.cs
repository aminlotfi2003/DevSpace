using DevSpace.Application.Common.Contracts.Identity;
using DevSpace.Application.Common.Contracts.Persistence;
using DevSpace.Application.Common.Models.Results;
using DevSpace.Domain.Entities;
using Mediator;

namespace DevSpace.Application.Features.Note.Commands.AddNote;

internal class AddNoteCommandHandler(IUnitOfWork uow, IApplicationUserManager userManager)
    : IRequestHandler<AddNoteCommand, OperationResult<bool>>
{
    public async ValueTask<OperationResult<bool>> Handle(AddNoteCommand req, CancellationToken ct)
    {
        var user = await userManager.GetUserByIdAsync(req.OwnerId, ct);

        if (user is null)
            return OperationResult<bool>.NotFoundResult("User not found.");

        var tagNames = req.Tags?
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Select(t => t.Trim())
            .Where(t => t.Length > 0)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList()
            ?? new List<string>();

        var resolvedTags = new List<Tag>(capacity: tagNames.Count);
        foreach (var tagName in tagNames)
        {
            var existing = await uow.NoteRepository.GetTagByNameAsync(tagName, ct);
            if (existing != null)
                resolvedTags.Add(existing);
            else
                resolvedTags.Add(new Tag { Name = tagName });
        }

        var note = new Domain.Entities.Note
        {
            OwnerId = req.OwnerId,
            User = user,
            Title = req.Title?.Trim() ?? string.Empty,
            Text = req.Text?.Trim() ?? string.Empty,
            Tags = new HashSet<Tag>()
        };

        foreach (var t in resolvedTags)
        {
            if (!note.Tags.Any(existing => string.Equals(existing.Name, t.Name, StringComparison.OrdinalIgnoreCase)))
                note.Tags.Add(t);
        }

        try
        {
            await uow.NoteRepository.AddNoteAsync(note, ct);
            await uow.CommitAsync(ct);

            // success
            return OperationResult<bool>.SuccessResult(true);
        }
        catch (Exception ex)
        {
            await uow.RollBackAsync(ct);
            return OperationResult<bool>.FailureResult($"Failed to add note: {ex.Message}", default);
        }
    }
}
