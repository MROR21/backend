using Desafio_root.Application.DTOs; 
using Desafio_root.Domain.Entities;
using Desafio_root.Domain.ValueObject;
using Desafio_root.Domain.IRepository;


namespace Desafio_root.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService (ITaskRepository taskRepository)
        {
            _repository = taskRepository;
        }

        public async Task<Guid> CreateNewTaskAsync(CreateTaskDTO dto) 
        {
            var titleValidate = TaskTitle.Create(dto.Title);

            var newTask = TaskItem.Create(dto.UserId, titleValidate, dto.Description, DateTime.SpecifyKind(dto.DueDate, DateTimeKind.Utc), dto.Priority);

            await _repository.ToAddAsync(newTask); 

            return newTask.Id;

        }


        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(Guid userId) 
        {
            var allTasks = await _repository.GetAllByUserIdAsync(userId);
            return allTasks;
        }


        public async Task<TaskItem> GetTaskByIdAsync(Guid id, Guid userId) 
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null) 
            {
                throw new Exception("Tarefa não encontrada.");
            }

            if (task.UserId != userId)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            return task;
        }

       

        public async Task UpdateTaskAsync(Guid id, UpdateTaskDTO dto, Guid userId)
        {
        
            var task = await GetTaskByIdAsync(id, userId);

            var newTitleValidate = TaskTitle.Create(dto.Title);

            task.UpdateTask(newTitleValidate, dto.Description, dto.DueDate, dto.Priority);

            await _repository.ToUpdateAsync(task);
        
        }



        public async Task UpdateTaskStatusAsync(Guid id, UpdateStatusDTO dto, Guid userId)
        {
            var task = await GetTaskByIdAsync(id,userId);

            task.UpdateStatus(dto.Status);

            await _repository.ToUpdateAsync(task);
        }



        public async Task DeleteTaskAsync(Guid id, Guid userId)
        {
            var task = await GetTaskByIdAsync(id, userId);

            await _repository.ToRemoveAsync(task);
        }

    }
}