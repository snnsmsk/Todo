using AutoMapper;
using ToDo.Data.DbContexts;
using ToDo.Data.Repository;

namespace ToDo.Business.Service
{
    public class BaseService
    {
        public IToDoDbContext _toDoDbContext { get; set; }
        public IMapper _mapper { get; set; }

        private ITodoRepository toDoRepository;

        public BaseService(IToDoDbContext toDoDbContext, IMapper mapper)
        {
            _toDoDbContext = toDoDbContext;
            _mapper = mapper;
        }


        public ITodoRepository TodoRepository
        {
            get
            {
                if (toDoRepository == null)
                {
                    toDoRepository = new ToDoRepository(_toDoDbContext);
                }
                return toDoRepository;
            }
        }

        public IToDoDbContext ToDoDbContext => _toDoDbContext;

        public void Commit() => _toDoDbContext.Commit();
    }
}
