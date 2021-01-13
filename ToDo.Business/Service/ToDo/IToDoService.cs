using System.Collections.Generic;
using ToDo.Api.Model;

namespace ToDo.Business.Service
{
    public interface IToDoService
    {
        ToDoDto Create(ToDoCreateDto toDo);
        void Delete(int id);
        ToDoDto Update(int id, ToDoUpdateDto toDo);
        ToDoDto Get(int id);
        IEnumerable<ToDoDto> GetToDos(ToDoSearchDto request);
    }
}