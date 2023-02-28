using System.Data;
using Contact.Core.Entities;
using Dapper.Contrib.Extensions;

namespace Contact.Core.DataAccess.Dapper;

public class DpEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        protected readonly IDbConnection _dbConnection;
        public DpEntityRepositoryBase(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public void Delete(T entity)
        {
            _dbConnection.Delete(entity);
        }

        public List<T> GetAll()
        {
            return _dbConnection.GetAll<T>().ToList();
        }

        public List<T> GetAll(Func<T, bool> filter)
        {
            return _dbConnection.GetAll<T>().Where(filter).ToList();
        }

        public T? GetByFilter(Func<T, bool> filter)
        {
            return _dbConnection.Get<T>(filter);
        }

        public T GetById(Guid id)
        {
            return _dbConnection.Get<T>(id);
        }


        public void Insert(T entity)
        {
            _dbConnection.Insert(entity);
        }

        public async Task<int> InsertAsync(T entity)
        {
            return await _dbConnection.InsertAsync(entity);
        }

        public void Update(T entity)
        {
            _dbConnection.Update(entity);
        }
    }
