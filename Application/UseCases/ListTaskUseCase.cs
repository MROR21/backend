using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class ListTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public ListTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public IEnumerable<TaskResponse> Execute()
    {
        var tasks = _taskRepository.GetAll();

        return tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Title = task.Title.ToString(),
            Description = task.Description,
            Priority = task.Priority,
            IsCompleted = task.IsCompleted,
            UserId = task.UserId
        });
    }
}