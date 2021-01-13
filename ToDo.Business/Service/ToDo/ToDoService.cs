using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Api.Model;
using ToDo.Business.Resource;
using ToDo.Data;
using ToDo.Data.DbContexts;
using ToDo.Data.Model;

namespace ToDo.Business.Service
{
    public class ToDoService : BaseService, IToDoService
    {
        public ToDoService(IToDoDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public ToDoDto Create(ToDoCreateDto toDo)
        {
            var dsToDo = _mapper.Map<DsToDo>(toDo);

            if (string.IsNullOrWhiteSpace(dsToDo.Title))
            {
                throw new TodoException(ToDoExceptionResource.ToDoCanNotBeEmpty);
            }

            dsToDo.Title = dsToDo.Title.Trim();

            TodoRepository.Add(dsToDo);

            Commit();

            return _mapper.Map<ToDoDto>(dsToDo);
        }

        public void Delete(int id)
        {
            var todo = TodoRepository.Get(id);

            if (todo == null)
                throw new TodoNotFoundException(ToDoExceptionResource.EntityNotFound);

            TodoRepository.Remove(todo);

            Commit();
        }

        public ToDoDto Get(int id)
        {
            var todo = TodoRepository.Get(id);

            if (todo == null)
                throw new TodoNotFoundException(ToDoExceptionResource.EntityNotFound);

            return _mapper.Map<ToDoDto>(todo);
        }

        public IEnumerable<ToDoDto> GetToDos(ToDoSearchDto request)
        {
            var query = TodoRepository.GetToDos(request);

            return _mapper.Map< IEnumerable<ToDoDto>>(query.ToList());
        }

        public ToDoDto Update(int id, ToDoUpdateDto toDo)
        {
            var dsTodo = TodoRepository.Get(id);

            if (dsTodo == null)
                throw new TodoNotFoundException(ToDoExceptionResource.EntityNotFound);

            if (string.IsNullOrWhiteSpace(toDo.Title))
            {
                throw new TodoException(ToDoExceptionResource.ToDoCanNotBeEmpty);
            }

            toDo.Title = toDo.Title.Trim();

            _mapper.Map(toDo, dsTodo);

            Commit();

            return _mapper.Map<ToDoDto>(dsTodo);
        }
    }
}
