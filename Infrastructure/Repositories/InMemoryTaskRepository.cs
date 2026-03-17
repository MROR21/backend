using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    public void Delete(Guid id)
    {
        var task = GetById(id);
        if (task != null)
            _tasks.Remove(task);
    }

    public IEnumerable<TaskItem> GetAll()
    {
        return _tasks;
    }

    public TaskItem? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Update(TaskItem task)
    {
        var existing = GetById(task.Id);
        if (existing != null)
        {
            _tasks.Remove(existing);
            _tasks.Add(task);
        }
    }
}