using Domain.ValueObjects;

namespace Application.DTOs;

public class CreateTaskRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public Guid UserId { get; set; }
}