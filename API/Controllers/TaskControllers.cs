using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Application.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly ListTasksUseCase _listTasksUseCase;
    private readonly CompleteTaskUseCase _completeTaskUseCase;

    public TaskController(
        CreateTaskUseCase createTaskUseCase,
        ListTasksUseCase listTasksUseCase,
        CompleteTaskUseCase completeTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _listTasksUseCase = listTasksUseCase;
        _completeTaskUseCase = completeTaskUseCase;
    }

    [HttpPost]
    public IActionResult Create(CreateTaskRequest request)
    {
        _createTaskUseCase.Execute(request);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _listTasksUseCase.Execute();
        return Ok(tasks);
    }

    [HttpPatch("{id}/complete")]
    public IActionResult Complete(Guid id)
    {
        var request = new CompleteTaskRequest { TaskId = id };
        _completeTaskUseCase.Execute(request);
        return Ok();
    }
}