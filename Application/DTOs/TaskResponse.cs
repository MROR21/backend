using Domain.ValueObjects;

namespace Application.DTOs;

public class TaskResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public bool IsCompleted { get; set; }

    public Guid UserId { get; set; }
}