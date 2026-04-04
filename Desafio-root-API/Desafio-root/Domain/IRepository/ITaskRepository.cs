using Desafio_root.Domain.Entities;
namespace Desafio_root.Domain.IRepository
{
    public interface ITaskRepository
    {
        
        Task <TaskItem?> GetByIdAsync (Guid id);
        Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(Guid userId);
        Task ToAddAsync(TaskItem task);
        Task ToUpdateAsync(TaskItem task);
        Task ToRemoveAsync(TaskItem task);


    }
}

