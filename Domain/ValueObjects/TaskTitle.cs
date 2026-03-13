namespace Domain.ValueObjects;

public class TaskTitle
{
    public string Value { get; }

    public TaskTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title cannot be empty");

        if (value.Length > 100)
            throw new ArgumentException("Title cannot exceed 100 characters");

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}