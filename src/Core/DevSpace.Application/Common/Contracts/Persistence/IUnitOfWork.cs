namespace DevSpace.Application.Common.Contracts.Persistence;

public interface IUnitOfWork
{
    public INoteRepository NoteRepository { get; }
    public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
    Task CommitAsync(CancellationToken cancellationToken);
    ValueTask RollBackAsync(CancellationToken cancellationToken);
}
