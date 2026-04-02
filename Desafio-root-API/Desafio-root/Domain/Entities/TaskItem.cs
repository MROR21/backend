using Desafio_root.Domain.ValueObject;
using System.Globalization;

namespace Desafio_root.Domain.Entities
{
    public class TaskItem
    {

       public Guid UserId{ get; private set; }
       public Guid Id { get; private set; }
       public TaskTitle Title { get; private set; }
       public string Description { get; private set; }
       public DateTime DueDate { get; private set; }
       public Priority Priority { get; private set; }
       public string Status { get; private set; }


        protected TaskItem() { }

        private TaskItem(Guid userId, TaskTitle title, string description, DateTime dueDate, Priority priority)
       {
           UserId = userId;
           Id = Guid.NewGuid();
           Title = title;
           Description = description;
           DueDate = dueDate;
           Priority = priority;
           Status = "Pendente";
       }


        public static TaskItem Create(Guid userId, TaskTitle title, string description, DateTime dueDate, Priority priority)
        {
            return new TaskItem(userId, title, description, dueDate, priority);
        }

        public void UpdateTask (TaskTitle newTitle, string newDescription, DateTime newDueDate, Priority newPriority)
        {   
            Title = newTitle;
            Description= newDescription;
            DueDate = newDueDate;
            Priority = newPriority;
        }

        public void UpdateStatus(string newStatus)
        {
            var statusForValidate = newStatus.Trim().ToLower().Replace("í", "i");

            Status = statusForValidate switch
            {
                "pendente" => "Pendente",
                "em andamento" => "Em Andamento",
                "concluida" => "Concluída",

                _ => throw new ArgumentException("Status inválido. Valores permitidos: Pendente, Em Andamento, Concluída.")
            };

            
        }


    }
}
