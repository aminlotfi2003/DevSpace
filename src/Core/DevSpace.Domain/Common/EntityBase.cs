#nullable disable

namespace DevSpace.Domain.Common;

public interface IEntity<TId>
{
    TId Id { get; }
}

public interface ITimeModification
{
    DateTimeOffset CreatedOn { get; set; }
    DateTimeOffset? ModifiedOn { get; set; }
}

public abstract class EntityBase<TId> : IEntity<TId>, ITimeModification
{
    public TId Id { get; protected set; } = default!;

    public override bool Equals(object obj)
    {
        if(obj is not EntityBase<TId> other)
            return false;

        if(ReferenceEquals(this, other))
            return true;

        if(GetType() != other.GetType())
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(EntityBase<TId> x, EntityBase<TId> y)
    {
        if (x is null && y is null)
            return true;

        if(x is null || y is null)
            return false;

        return x.Equals(y);
    }

    public static bool operator !=(EntityBase<TId> x, EntityBase<TId> y)
    {
        return !(x == y);
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}

public abstract class EntityBase : EntityBase<int>
{

}
