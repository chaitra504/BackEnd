using CLI.Models;
using CLI.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CLI.Controllers;

[EnableCors("DefaultCorsPolicy")]

[ApiController]
[Route("[controller]")]
public class TaskItemController : ControllerBase
{
     private readonly ILogger<TaskItemController> _logger;

     private ITaskItemService _taskItemService;
    public TaskItemController(ILogger<TaskItemController> logger,ITaskItemService taskItemser)
    {
        _logger = logger;
        _taskItemService = taskItemser;

    }

     [HttpGet]
    [Route("GetAllTaskItem")]
    public IEnumerable<TaskItem> GetAllTaskItem(long listId)
    {
        IEnumerable<TaskItem> result =  _taskItemService.GetAll(listId);
        return result;
    }

    [HttpPost]
    [Route("AddTaskItem")]
    public long? AddTaskItem(TaskItem item)
    {
        long? listId = _taskItemService.AddTaskItem(item);
        return listId;
    }


    [HttpPut]
    [Route("UpdateTaskItem")]
    public long UpdateTaskItem(TaskItem item)
    {
       long listId = _taskItemService.UpdateTaskItem(item);
       return listId;
    }

    [HttpGet]
    [Route("GetTaskItem")]
    public TaskItem GetTaskItem(long id)
    {
        var result= _taskItemService.Get(id);
        if(result==null)
        result = new TaskItem();
        return result;
    }

    [HttpDelete]
    [Route("DeleteTaskItem")]
    public bool DeleteTaskItem(long id)
    {
        return _taskItemService.DeleteTaskItem(id);
    }

}