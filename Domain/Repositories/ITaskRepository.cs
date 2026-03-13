using Domain.Entities;

namespace Domain.Repositories;

public interface ITaskRepository
{
    TaskItem? GetById(Guid id);

    IEnumerable<TaskItem> GetAll();

    void Add(TaskItem task);

    void Update(TaskItem task);

    void Delete(Guid id);
}