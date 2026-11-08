using TaskManagerApi.Core;

namespace Core;

public class TasksService
{
    private readonly IRepository _repository;

    public TasksService(IRepository repository)
    {
        _repository = repository;
    }
    public List<TaskItem> GetAllTasks()
    {
        return _repository.GetAllTasks().Where(t=>t.IsDone==false).ToList();
    }
    public void AddNormalTask(TaskItem newTask)
    {
        var tasks = _repository.GetAllTasks();
        newTask.Id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        newTask.IsDone = false;

        if (newTask.DueDate < DateOnly.FromDateTime(DateTime.Today))
            newTask.DueDate = DateOnly.FromDateTime(DateTime.Today);

        tasks.Add(newTask);
        _repository.SaveTasks(tasks);
    }
    public List<TaskItem> SearchTasks(Urgency? urgency, bool? isDone, string? title)
    {
        return _repository.SearchTasks(urgency, isDone, title);
    }
}
