using System.Net;
using System.Net.Mail;
using ClosedXML.Excel;
using Core;
using Microsoft.AspNetCore.Mvc;
using Repositpry;
using TaskManagerApi.Core;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private const string FilePath = "tasks.xlsx";
    private readonly TasksService _service= new TasksService(new ExcelRepository());
    private readonly IConfiguration _config;

    public TasksController(IConfiguration config)
    {
        _config = config;
    }

    // ---------- 1. כל המשימות ----------
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllTasks());
    }

    // ---------- 2. הוספת משימה ----------
    [HttpPost]
    public IActionResult Add(TaskItem newTask)
    {
        _service.AddNormalTask(newTask);
        return Ok(newTask);
    }

    // ---------- 3. חיפוש לפי params ----------
    [HttpGet("search")]
    public IActionResult Search(Urgency? urgency,bool? isDone,string? title)
    {
       var filteredTasks = _service.SearchTasks(urgency, isDone, title);
       
    //    var tasksByUrgency= filteredTasks.Where(t => t.Urgency == urgency);
        return Ok(filteredTasks);
    }

}