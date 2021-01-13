using Microsoft.EntityFrameworkCore;
using ToDo.Data.Model;

namespace ToDo.Data.DbContexts
{
    public interface IToDoDbContext
    {
        DbSet<DsToDo> ToDos { get; }

        void Commit();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}