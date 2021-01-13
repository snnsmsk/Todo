using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Api.Model;
using ToDo.Business.Service;

namespace ToDo.Api.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class ToDoController : ToDoBaseController
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService, IMapper mapper) : base(mapper)
        {
            _toDoService = toDoService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(ToDoDto), (int)HttpStatusCode.OK)]
        public IActionResult Get([FromQuery] ToDoSearchDto request)
        {
            var todos = _toDoService.GetToDos(request);
            return Ok(todos);
        }

        [HttpGet()]
        [Route("{id:int}", Name = "GetToDo")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ToDoDto), (int)HttpStatusCode.OK)]
        public IActionResult GetToDo(int id)
        {
            var firm = _toDoService.Get(id);
            return Ok(firm);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ToDoDto), (int)HttpStatusCode.Created)]
        public IActionResult Post([FromBody] ToDoCreateDto toDoCreateDto)
        {
            if (toDoCreateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = _toDoService.Create(toDoCreateDto);
            return CreatedAtRoute("GetToDo", new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ToDoDto), (int)HttpStatusCode.OK)]
        public IActionResult Put(int id, [FromBody] ToDoUpdateDto toDoUpdateDto)
        {
            if (toDoUpdateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todo = _toDoService.Update(id, toDoUpdateDto);
            return Ok(todo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _toDoService.Delete(id);
            return Ok();
        }
    }
}
