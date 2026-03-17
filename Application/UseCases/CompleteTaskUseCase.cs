using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class CompleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CompleteTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void Execute(CompleteTaskRequest request)
    {
        var task = _taskRepository.GetById(request.TaskId);

        if (task == null)
            throw new Exception("Task not found");

        task.Complete();

        _taskRepository.Update(task);
    }
}