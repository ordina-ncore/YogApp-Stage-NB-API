using LanguageExt.Common;

namespace YogApp.Infrastructure.Repositories;

public interface IRepository<TEntity>
    where TEntity : EntityBase
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct);
    void AddChanges(TEntity entity);
    Task<Result<Guid>> RemoveByIdAsync(Guid id, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}

public abstract class Repository<TEntity> : IRepository<TEntity>, IAsyncDisposable
        where TEntity : EntityBase
{
    public void AddChanges(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Guid>> RemoveByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}