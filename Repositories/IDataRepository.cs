
namespace CLI.Repositories
{
public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity? Get(long id);
        long? Add(TEntity entity);
        long Update(TEntity entity);
        bool Delete(long entityId);
    }
}