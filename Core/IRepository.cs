namespace TaskManagerApi.Core;

public interface IRepository
{
    List<TaskItem> GetAllTasks();
    bool SaveTasks(List<TaskItem> tasks);
    List<TaskItem> SearchTasks(Urgency? urgency, bool? isDone, string? title);
}