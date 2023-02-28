using Contact.Core.Entities;

namespace Contact.Core.DataAccess;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    List<T> GetAll();
    List<T> GetAll(Func<T, bool> filter);
    T? GetByFilter(Func<T, bool> filter);
    T GetById(Guid id);
    void Insert(T entity);
    Task<int> InsertAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}