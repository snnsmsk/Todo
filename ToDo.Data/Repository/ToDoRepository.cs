using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Api.Model;
using ToDo.Data.DbContexts;
using ToDo.Data.Model;

namespace ToDo.Data.Repository
{
    public class ToDoRepository : BaseRepository<DsToDo>, ITodoRepository
    {
        public ToDoRepository(IToDoDbContext databaseContext) : base(databaseContext)
        {
        }

        public IQueryable<DsToDo> GetToDos(ToDoSearchDto request)
        {
            IQueryable<DsToDo> todos = _toDoDbContext.ToDos.Where(p => !p.Deleted);

            if (!string.IsNullOrWhiteSpace(request.Title))
                todos = todos.Where(m => m.Title.Contains(request.Title.Trim()));

            if (request.Completed.HasValue)
                todos = todos.Where(m => m.Completed == request.Completed.Value);

            todos = todos.OrderByExt(request.OrderBy);

            return todos;
        }
    }
}
