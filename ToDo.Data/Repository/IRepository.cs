using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDo.Data.Model;

namespace ToDo.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        bool Any(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void RemoveRange<T>(IEnumerable<T> entities) where T : ToDoEntity;
        void Remove<T>(T entity) where T : ToDoEntity;
    }
}