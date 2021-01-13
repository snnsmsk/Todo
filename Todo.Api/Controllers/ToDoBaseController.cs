using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    public class ToDoBaseController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        public ToDoBaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
