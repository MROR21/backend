using Microsoft.AspNetCore.Mvc;
using Desafio_root.Application.DTOs;
using Desafio_root.Application.Services;
using Microsoft.AspNetCore.Authorization; 

namespace Desafio_root.Controllers
{
    [Authorize]
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO dto)
        {
            try
            {
                var taskId = await _taskService.CreateNewTaskAsync(dto);

                return CreatedAtAction(nameof(GetTaskById), new { id = taskId, userId = dto.UserId }, new { Message = "Tarefa criada com sucesso", Id = taskId });

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Erro = "Ocorreu um erro interno no Servidor." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery] Guid userId, [FromQuery] string? status)
        {
            try
            {

            var tasks = await _taskService.GetAllTasksAsync(userId);

            if (!string.IsNullOrWhiteSpace(status))
            {
                tasks = tasks.Where(t => t.Status.ToLower() == status.ToLower());
            }

                var response = tasks.Select(t => new TaskResponseDTO
                (
                    t.Id,
                    t.Title.Title,
                    t.Description,
                    t.Priority,
                    t.DueDate,
                    t.Status
                ));

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Erro = "Ocorreu um erro ao buscar as tarefas." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id, [FromQuery] Guid userId)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(id, userId);
                var response = new TaskResponseDTO
                (
                    task.Id,
                    task.Title.Title,
                    task.Description,
                    task.Priority,
                    task.DueDate,
                    task.Status
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { Erro = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromQuery] Guid userId, [FromBody] UpdateTaskDTO dto)
        {
            try
            {
                await _taskService.UpdateTaskAsync(id, dto, userId);

                return NoContent();
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
            catch (Exception ex) when (ex.Message == "Tarefa não encontrada.")
            {
                return NotFound(new { Erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Erro = "Ocorreu um erro ao atualizar a tarefa." });
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] Guid userId, [FromBody] UpdateStatusDTO dto)
        {
            try
            {
                await _taskService.UpdateTaskStatusAsync(id, dto, userId);
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
            catch (Exception ex) when (ex.Message == "Tarefa não encontrada.")
            {
                return NotFound(new { Erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Erro = "Ocorreu um erro ao atualizar a tarefa." });
            }
        }


        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteTask(Guid id, [FromQuery] Guid userId)
        {
            try
            {
                await _taskService.DeleteTaskAsync(id, userId);

                return NoContent();
            }
            catch (Exception ex) when (ex.Message == "Tarefa não encontrada.")
            {
                return NotFound(new { Erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Erro = "Ocorreu um erro ao deletar a tarefa." });
            }
        }

    }
}
