namespace Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Status { get; private set; }

    public DateTime DueDate { get; private set; }

    public string Priority { get; private set; }

    public TaskItem(
        string title,
        string description,
        DateTime dueDate,
        string priority)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = "Pending";
        DueDate = dueDate;
        Priority = priority;
    }
}