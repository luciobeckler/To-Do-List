using Microsoft.AspNetCore.Mvc;
using ToDo.API.DTOs;
using ToDo.API.Models;
using ToDo.API.Services.Groups;
using ToDo.API.Services.ToDoTasks;

namespace ToDo.API.Controllers.ToDoTasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTasksService _toDoTasksService;
        private readonly IGroupsService _groupsService;

        public ToDoTasksController(IToDoTasksService toDoTasksService, IGroupsService groupsService)
        {
            _toDoTasksService = toDoTasksService;
            _groupsService = groupsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ToDoTask>>> GetAll()
        {
            var tasks = await _toDoTasksService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ToDoTask>> GetById(int id)
        {
            var task = await _toDoTasksService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.ToDoTask>> Create(ToDoTaskDTO todoTaskDTO)
        {
            var todoTask = new Models.ToDoTask()
            {
                Titulo = todoTaskDTO.Titulo,
                Descricao = todoTaskDTO.Descricao,
                Status = todoTaskDTO.Status,
                Prioridade = todoTaskDTO.Prioridade,
                Data_inicio = todoTaskDTO.DataInicio,
                Data_fim = todoTaskDTO.DataFim,
                GroupId = todoTaskDTO.GrupoId
            };

            try
            {
                await _toDoTasksService.AddAsync(todoTask);
                return Ok(todoTask);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update(int id, ToDoTaskDTO todoTaskDTO)
        {
            try
            {
                var existingTask = await _toDoTasksService.GetByIdAsync(id);
                if (existingTask == null)
                    return NotFound("Task not found.");

                existingTask.Titulo = todoTaskDTO.Titulo;
                existingTask.Descricao = todoTaskDTO.Descricao;
                existingTask.Status = todoTaskDTO.Status;
                existingTask.Prioridade = todoTaskDTO.Prioridade;
                existingTask.Data_inicio = todoTaskDTO.DataInicio;
                existingTask.Data_fim = todoTaskDTO.DataFim;
                existingTask.GroupId = todoTaskDTO.GrupoId;

                await _toDoTasksService.UpdateAsync(existingTask);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _toDoTasksService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}