using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Application.DTOs;

namespace Application.UseCases;

public class CreateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(CreateTaskRequest request)
    {
        var title = new TaskTitle(request.Title);

        var task = new TaskItem(
            Guid.NewGuid(),
            title,
            request.Description,
            request.Priority,
            request.UserId
        );

        _taskRepository.Add(task);
    }
}