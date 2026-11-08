namespace TaskManagerApi.Core;

public enum Urgency
{
    Low,
    Medium,
    High
}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public DateOnly DueDate { get; set; }
    public Urgency Urgency { get; set; }
    public bool IsDone { get; set; }
}
public record TaskItemDto(string Title, DateOnly DueDate, Urgency Urgency);
