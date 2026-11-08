using ClosedXML.Excel;
using TaskManagerApi.Core;

namespace Repositpry;

public class ExcelRepository : IRepository
{
        private const string FilePath = "tasks.xlsx";

    public List<TaskItem> GetAllTasks()
    {
 var tasks = new List<TaskItem>();

        if (!System.IO.File.Exists(FilePath))
            return tasks;

        using var workbook = new XLWorkbook(FilePath);
        var sheet = workbook.Worksheet(1);

        // מדלגים על שורת הכותרות (שורה 1)
        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            tasks.Add(new TaskItem
            {
                Id = row.Cell(1).GetValue<int>(),
                Title = row.Cell(2).GetString(),
                DueDate = DateOnly.Parse(row.Cell(3).GetString()),
                Urgency = Enum.Parse<Urgency>(row.Cell(4).GetString()),
                IsDone = row.Cell(5).GetBoolean()
            });
        }

        return tasks;    }

    public bool SaveTasks(List<TaskItem> tasks)
    {
        using var workbook = new XLWorkbook();
        var sheet = workbook.AddWorksheet("Tasks");

        // כותרות
        sheet.Cell(1, 1).Value = "Id";
        sheet.Cell(1, 2).Value = "Title";
        sheet.Cell(1, 3).Value = "DueDate";
        sheet.Cell(1, 4).Value = "Urgency";
        sheet.Cell(1, 5).Value = "IsDone";

        // נתונים
        for (int i = 0; i < tasks.Count; i++)
        {
            var task = tasks[i];
            sheet.Cell(i + 2, 1).Value = task.Id;
            sheet.Cell(i + 2, 2).Value = task.Title;
            sheet.Cell(i + 2, 3).Value = task.DueDate.ToString("yyyy-MM-dd");
            sheet.Cell(i + 2, 4).Value = task.Urgency.ToString();
            sheet.Cell(i + 2, 5).Value = task.IsDone;
        }

        workbook.SaveAs(FilePath);
        return true;
    }

    public List<TaskItem> SearchTasks(Urgency? urgency, bool? isDone, string? title)
    {
        var tasks = GetAllTasks();
        IEnumerable<TaskItem> filteredTasks = tasks;
        if (urgency.HasValue)
        {
            filteredTasks = filteredTasks.Where(t => t.Urgency == urgency.Value);
        }
        if (isDone.HasValue)
        {
            filteredTasks = filteredTasks.Where(t => t.IsDone == isDone.Value)  ;
        }
        if (title != null)
        {
            filteredTasks = filteredTasks.Where(t => t.Title.Contains(title));
        }   
        
        return filteredTasks.ToList();}
}