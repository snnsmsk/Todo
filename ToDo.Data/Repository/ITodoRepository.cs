using System.Linq;
using ToDo.Api.Model;
using ToDo.Data.Model;

namespace ToDo.Data.Repository
{
    public interface ITodoRepository : IRepository<DsToDo>
    {
        IQueryable<DsToDo> GetToDos(ToDoSearchDto request);
    }
}