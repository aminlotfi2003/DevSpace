using DevSpace.Domain.Entities;

namespace DevSpace.Application.Common.Contracts.Persistence;

public interface INoteRepository
{
    Task AddNoteAsync(Note note, CancellationToken cancellationToken);
    Task<List<Note>> GetAllUserNotesAsync(int userId, CancellationToken cancellationToken);
    Task<List<Note>> GetAllNotesWithRelatedUserAsync(CancellationToken cancellationToken);
    Task<Note> GetUserNoteByIdAndUserIdAsync(int userId, int noteId, bool trackEntity, CancellationToken cancellationToken);
    Task DeleteUserNotesAsync(int userId, CancellationToken cancellationToken);
}
