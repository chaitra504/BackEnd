using CLI.Models;
using CLI.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CLI.Controllers;

[EnableCors("DefaultCorsPolicy")]

[ApiController]
[Route("[controller]")]
public class TaskManagerController : ControllerBase
{
     private readonly ILogger<TaskManagerController> _logger;
     private ITaskListService _taskListService;
    public TaskManagerController(ILogger<TaskManagerController> logger,ITaskListService taskListSer)
    {
        _logger = logger;
        _taskListService = taskListSer;

    }

    [HttpGet]
    [Route("GetAll")]
    public IEnumerable<TaskList> GetAll()
    {
        IEnumerable<TaskList> result =  _taskListService.GetAll();
        return result;
    }

    [HttpPost]
    [Route("AddTaskList")]
    public long? AddTaskList(TaskList item)
    {
        long? listId = _taskListService.AddTaskList(item);
        return listId;
    }

    [HttpGet]
    [Route("GetTaskList")]
    public TaskList GetTaskList(long id)
    {
        var result= _taskListService.Get(id);
        if(result==null)
        result = new TaskList();
        return result;
    }

    [HttpDelete]
    [Route("DeleteTaskList")]
    public bool DeleteTaskList(long id)
    {
        return _taskListService.DeleteTaskList(id);
    }

      [HttpPut]
    [Route("UpdateTaskList")]
    public long UpdateTaskList(TaskList item)
    {
       long listId = _taskListService.UpdateTaskList(item);
       return listId;
    }
}