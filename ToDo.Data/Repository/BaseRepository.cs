using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Data.DbContexts;
using ToDo.Data.Model;

namespace ToDo.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : ToDoEntity
    {
        protected IToDoDbContext _toDoDbContext { get; private set; }
        protected DbSet<TEntity> entities { get; private set; }

        protected BaseRepository(IToDoDbContext toDoDbContext)
        {
            _toDoDbContext = toDoDbContext;
            entities = _toDoDbContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            var entity  = entities.Find(id);
            return entity != null ? (entity.Deleted ? null : entity) : null; 
        }

        public bool Any(int id)
        {
            return entities.Find(id) != null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.entities.AddRange(entities);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : ToDoEntity
        {
            entities.ToList().ForEach(m => m.Deleted = true);
        }

        public void Remove<T>(T entity) where T : ToDoEntity
        {
            entity.Deleted = true;
        }
    }
}
